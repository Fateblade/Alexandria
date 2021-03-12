using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Configuration.ConfigObjects;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.EventBrokerage;
using Fateblade.Components.CrossCutting.CoCo.Core.Configuration.NewtonsoftJson;
using Fateblade.Components.CrossCutting.ExceptionFormatter.SimpleListFormat;
using System.IO;
using Fateblade.Components.CrossCutting.Logging.Csv;
using Fateblade.Components.Data.GenericDataStoring.NewtonsoftJson;
using Fateblade.Components.Logic.Foundation.Translation;

namespace Registrations.Client.Mappings
{
    public class KernelInitializer : IKernelInitializer
    {
        public void Initialize(ICoCoKernel kernel)
        {
            string pathToConfig = Path.Combine(Directory.GetCurrentDirectory(), "MergedConfig.json");

            //core components
            kernel.Register<IBootstrapper, Bootstrapper>();
            kernel.Register<IEventBroker, EventBroker>();
            kernel.RegisterUnique<IConfigurationRepository, DatabaseConfigurationRepository>(new DatabaseConfigurationRepository(pathToConfig));
            kernel.Register<IConfigurator, Configurator>();
            kernel.Register<IConfigObjectProvider, ConfigObjectProvider>();
            kernel.RegisterComponent<SimpleListExceptionFormatterComponentActivator>();
            kernel.RegisterComponent<LoggingCsvComponentActivator>();

            //generics
            kernel.RegisterComponent<GenericDataStoringActivator>();
            kernel.RegisterComponent<TranslationComponentActivator>();

            //application specific components
        }
    }
}
