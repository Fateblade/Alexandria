using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.Logic.Domain.EnvironmentManagement.Contract;

namespace Fateblade.Alexandria.Logic.Domain.EnvironmentManagement
{
    public class EnvironmentManagementComponentActivator : IComponentActivator
    {
        public void Activated()
        {
        }

        public void Activating()
        {
        }

        public void AddMessageSubscriptions(IEventBroker broker)
        {
        }

        public void Configure(IConfigurator config)
        {
        }

        public void Deactivated()
        {
        }

        public void Deactivating()
        {
        }

        public void RegisterMappings(ICoCoKernel kernel)
        {
            kernel.Register<IConnectionManager, ConnectionManager>();
            kernel.Register<IInfluenceManager, InfluenceManager>();
            kernel.Register<ILocationManager, LocationManager>();
            kernel.Register<IPlaneManager, PlaneManager>();
            kernel.Register<IWorldManager, WorldManager>();
        }
    }
}
