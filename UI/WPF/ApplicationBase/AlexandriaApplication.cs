using System.Windows;
using System.Windows.Threading;
using Alexandria.UI.WPF.Modules.CommonTranslations;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.UI.WPF.Client;
using Fateblade.Components.CrossCutting.CommonMessages.Contract.Messages;
using Fateblade.Components.CrossCutting.ExceptionFormatter.Contract;
using Fateblade.Components.CrossCutting.Logging.Contract;
using Fateblade.Components.CrossCutting.Logging.Contract.DataClasses;
using Fateblade.Components.Logic.Foundation.ApplicationBaseManager.Contract;
using Fateblade.PersonManagementApp.CoCo.Core.NinjectPrismAdapter;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Ninject;

namespace Fateblade.Alexandria.UI.WPF.ApplicationBase
{
    public abstract class AlexandriaApplication : PrismApplication
    {
        protected readonly KernelContainer KernelContainer = new();
        protected bool ModulesInitialized;
        protected IEventBroker EventBroker;

        protected override IContainerExtension CreateContainerExtension()
        {
            return KernelContainer.CastedKernel;
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CommonDialogsModule>();
            moduleCatalog.AddModule<CommonTranslationModule>();

            InitializeModules();
        }

        protected override void InitializeModules()
        {
            if (ModulesInitialized) return;

            IModuleManager manager = Container.Resolve<IModuleManager>();

            manager.Run();

            ModulesInitialized = true;

        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            InitializeTranslationStringProvider(KernelContainer.Kernel);
        }

        protected abstract void InitializeTranslationStringProvider(ICoCoKernel kernel);

        protected override void ConfigureViewModelLocator()
        {
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((tIn) =>
            {
                var viewName = tIn.FullName;
                var viewModelName = string.Empty;

                if (!string.IsNullOrWhiteSpace(viewName))
                {
                    viewModelName = viewName.EndsWith("View")
                        ? viewName + "Model"
                        : viewName + "ViewModel";
                }

                var viewModelType = Type.GetType(viewModelName);


                return viewModelType;
            });

            ViewModelLocationProvider.SetDefaultViewModelFactory((view, type) =>
            {
                Type viewModelType = null;

                if (type?.FullName?.EndsWith("ViewModel") == false)
                {
                    var viewType = view.GetType();
                    var viewName = viewType.FullName;
                    var viewModelName = string.Empty;

                    if (!string.IsNullOrWhiteSpace(viewName))
                    {
                        viewModelName = viewName.EndsWith("View")
                            ? viewName + "Model"
                            : viewName + "ViewModel";
                    }

                    viewModelType = Type.GetType(viewModelName);
                }

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

        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherUnhandledException += OnDispatcherUnhandledException;

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            EventBroker?.Raise(new ShutdownIssuedMessage());
            Container.Resolve<IApplicationConfigManager>().SaveApplicationConfig();

            DispatcherUnhandledException -= OnDispatcherUnhandledException;
            base.OnExit(e);
        }

        protected virtual void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                var prismLogger = Container.Resolve<ILoggerFacade>();
                var logger = Container.Resolve<ILogger>();
                var dialogOrchestrator = Container.Resolve<ICommonDialogOrchestrator>();
                var messageFormatter = Container.Resolve<IExceptionMessageFormatter>();

                var errorMessage = messageFormatter.FormatAllMessagesToString(e.Exception);
                prismLogger.Log(errorMessage, Category.Exception, Priority.High);
                logger.Log(LoggingPriority.High, LoggingType.Exception, errorMessage);

                if (errorMessage.Length > 300)
                {
                    errorMessage = $"{errorMessage[..300]}...{Environment.NewLine}Whole error was written to log";
                }

                if (ModulesInitialized)
                {
                    dialogOrchestrator.ShowErrorDialog(errorMessage, "Unbekannter Fehler!");
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
