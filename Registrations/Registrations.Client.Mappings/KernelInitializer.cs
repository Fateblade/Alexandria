using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Configuration.ConfigObjects;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.EventBrokerage;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement;
using Fateblade.Alexandria.Logic.Domain.Environment.EnvironmentManagement;
using Fateblade.Alexandria.Logic.Domain.GearManagement;
using Fateblade.Alexandria.Logic.Domain.MetaManagement;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice;
using Fateblade.Components.CrossCutting.CoCo.Core.Configuration.NewtonsoftJson;
using Fateblade.Components.CrossCutting.ExceptionFormatter.SimpleListFormat;
using Fateblade.Components.CrossCutting.Logging.Csv;
using Fateblade.Components.Data.GenericDataStoring.NewtonsoftJson;
using Fateblade.Components.Logic.Foundation.Orchestration;
using Fateblade.Components.Logic.Foundation.Translation;
using Fateblade.Components.Logic.GenericManager;
using Fateblade.Components.UI.WPF.ViewModelMapper;
using System.IO;

namespace Fateblade.Alexandria.Registrations.Client.Mappings
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
            kernel.RegisterComponent<GenericManagerComponentActivator>();

            //application specific components
            kernel.RegisterComponent<DiceActivator>();
            kernel.RegisterComponent<EntitiesManagementComponentActivator>();
            kernel.RegisterComponent<EnvironmentManagementComponentActivator>();
            kernel.RegisterComponent<GearManagementComponentActivator>();
            kernel.RegisterComponent<MetaManagementComponentActivator>();
            kernel.RegisterComponent<OrchestrationComponentActivator>();
            kernel.RegisterComponent<ViewModelMapperComponentActivator>();
        }
    }
}
