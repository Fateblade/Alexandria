using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.Registrations.Client.Mappings;
using Fateblade.Alexandria.UI.WPF.Base.ActionBar;
using Fateblade.Alexandria.UI.WPF.Client.Windows;
using Fateblade.Components.CrossCutting.CommonMessages.Contract.Messages;
using Fateblade.Components.CrossCutting.ExceptionFormatter.Contract;
using Fateblade.Components.CrossCutting.Logging.Contract;
using Fateblade.Components.CrossCutting.Logging.Contract.DataClasses;
using Fateblade.Components.Logic.Foundation.Translation.Contract;
using Fateblade.PersonManagementApp.CoCo.Core.NinjectPrismAdapter;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Ninject;
using System;
using System.Windows;
using System.Windows.Threading;

namespace Fateblade.Alexandria.UI.WPF.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        private readonly KernelContainer _kernelContainer;
        private bool _modulesInitialized;  //modules will be loaded after the shell is initialized

        public App()
        {
            _kernelContainer = new KernelContainer();
        }

        protected override IContainerExtension CreateContainerExtension()
        {
            return _kernelContainer.CastedKernel;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //mappings
            new KernelInitializer().Initialize(_kernelContainer.Kernel);

            //ui specific mappings
            _kernelContainer.CastedKernel.RegisterUnique<IActionMenuBarManager, ActionMenuBarManager>(new ActionMenuBarManager());


            //dialogs
            

            //misc


            //CoCo Bootstrapper
            IBootstrapper bootstrapper = _kernelContainer.Kernel.Get<IBootstrapper>();
            bootstrapper.ActivatingAll();
            bootstrapper.ActivatedAll();
            bootstrapper.RegisterAllMappings(_kernelContainer.Kernel);

            //translations
            configureTranslations();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CommonDialogsModule>();
        }

        protected override void InitializeModules()
        {
            IModuleManager manager = _kernelContainer.CastedKernel.Resolve<IModuleManager>();
            
            manager.Run();

            _modulesInitialized = true;
        }

        protected void configureTranslations() //todo think about using modules if project gets too large
        {
            ITranslationStringProvider translationProvider = _kernelContainer.Kernel.Get<ITranslationStringProvider>();

            //translationProvider.LoadStringResourcesForDefaultLanguage("ResourceCategoryStrings_de");
            //translationProvider.LoadStringResourcesForDefaultLanguage("TradeUnitStrings_de");
        }

        protected override void ConfigureViewModelLocator()
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory((view, type) =>
            {
                Type viewType = view.GetType();
                var viewName = viewType.FullName;
                var viewModelName = string.Empty;

                if (!string.IsNullOrWhiteSpace(viewName))
                {
                    viewModelName = viewName.EndsWith("View")
                        ? viewName + "Model"
                        : viewName + "ViewModel";
                }

                var viewModelType = Type.GetType(viewModelName);

                if (viewModelType == null)
                {
                    return Container.Resolve(type);
                }
                else
                {
                    return Container.Resolve(viewModelType);
                }
            });
        }

        protected override Window CreateShell()
        {
            return this.Container.Resolve<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherUnhandledException += OnDispatcherUnhandledException;

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Container.Resolve<IEventBroker>().Raise(new ShutdownIssuedMessage());
            DispatcherUnhandledException -= OnDispatcherUnhandledException;

            base.OnExit(e);
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            //Todo: modularize into error handling or at least capsulate in separate class
            try
            {
                ILoggerFacade prismLogger = Container.Resolve<ILoggerFacade>();
                ILogger logger = Container.Resolve<ILogger>();
                ICommonDialogOrchestrator commonDialogOrchestrator = Container.Resolve<ICommonDialogOrchestrator>();
                IExceptionMessageFormatter messageFormatter = Container.Resolve<IExceptionMessageFormatter>();

                var errorMessage = messageFormatter.FormatAllMessagesToString(e.Exception);
                prismLogger.Log(errorMessage, Category.Exception, Priority.High);
                logger.Log(LoggingPriority.High, LoggingType.Exception, errorMessage);

                if (errorMessage.Length > 300)
                {
                    errorMessage = $"{errorMessage.Substring(0, 300)}...{Environment.NewLine}Whole error was written to log";
                }

                if (_modulesInitialized)
                {
                    commonDialogOrchestrator.ShowErrorDialog(errorMessage, "Unbekannter Fehler!");
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }

                e.Handled = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not display exception info to user. See inner exception for original exception", ex);
            }
        }
    }
}
