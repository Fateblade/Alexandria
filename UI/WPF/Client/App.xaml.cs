using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Components.CrossCutting.CommonMessages.Contract.Messages;
using Fateblade.Components.CrossCutting.ExceptionFormatter.Contract;
using Fateblade.Components.CrossCutting.Logging.Contract;
using Fateblade.Components.CrossCutting.Logging.Contract.DataClasses;
using Prism.Ioc;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Ninject;
using System;
using System.Windows;
using System.Windows.Threading;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using Fateblade.Alexandria.UI.WPF.Client.Dialogs;
using Fateblade.Alexandria.UI.WPF.Client.Windows;
using Fateblade.Components.Logic.Foundation.Translation.Contract;
using Fateblade.PersonManagementApp.CoCo.Core.NinjectPrismAdapter;
using Prism.Services.Dialogs;
using Registrations.Client.Mappings;

namespace Fateblade.Alexandria.UI.WPF.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        private readonly KernelContainer _kernelContainer;

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
            //dialogs
            containerRegistry.RegisterDialog<ErrorMessageDialog, ErrorMessageDialogViewModel>();
            
            //misc


            //CoCo Bootstrapper
            var bootstrapper = _kernelContainer.Kernel.Get<IBootstrapper>();
            bootstrapper.ActivatingAll();
            bootstrapper.ActivatedAll();
            bootstrapper.RegisterAllMappings(_kernelContainer.Kernel);

            //translations
            configureTranslations();
        }

        protected void configureTranslations() //todo think about using modules if project gets too large
        {
            var translationProvider = _kernelContainer.Kernel.Get<ITranslationStringProvider>();

            //translationProvider.LoadStringResourcesForDefaultLanguage("ResourceCategoryStrings_de");
            //translationProvider.LoadStringResourcesForDefaultLanguage("TradeUnitStrings_de");
        }

        protected override void ConfigureViewModelLocator()
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory((view, type) =>
            {
                var viewType = view.GetType();
                var viewName = viewType.FullName;
                var viewAssemblyName = viewType.Assembly.FullName;

                var viewModelName = viewName.EndsWith("View")
                    ? viewName + "Model"
                    : viewName + "ViewModel";

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
            try
            {
                var prismLogger = Container.Resolve<ILoggerFacade>();
                var logger = Container.Resolve<ILogger>();
                var dialogService = Container.Resolve<IDialogService>();
                var messageFormatter = Container.Resolve<IExceptionMessageFormatter>();

                var errorMessage = messageFormatter.FormatAllMessagesToString(e.Exception);
                prismLogger.Log(errorMessage, Category.Exception, Priority.High);
                logger.Log(LoggingPriority.High, LoggingType.Exception, errorMessage);

                if (errorMessage.Length > 300)
                {
                    errorMessage = $"{errorMessage.Substring(0, 300)}...{Environment.NewLine}Whole error was written to log";
                }

                var parameters = new DialogParameters
                {
                    {nameof(ErrorDialogCreationInformation), new ErrorDialogCreationInformation("Unbekannter Fehler!", errorMessage)}
                };

                dialogService.Show(nameof(ErrorMessageDialog), parameters, result => {});

                e.Handled = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not display exception info to user. See inner exception for original exception", ex);
            }
        }
    }
}
