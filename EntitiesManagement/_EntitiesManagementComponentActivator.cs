using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement
{
    public class EntitiesManagementComponentActivator : IComponentActivator
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
            kernel.Register<IDeityManager, DeityManager>();
            kernel.Register<IFactionManager, FactionManager>();
            kernel.Register<IGroupManager, GroupManager>();
            kernel.Register<IMonsterManager, MonsterManager>();
            kernel.Register<INonPlayerCharacterManager, NonPlayerCharacterManager>();
            kernel.Register<IPantheonManager, PantheonManager>();
            kernel.Register<IPlayerCharacterManager, PlayerCharacterManager>();
            kernel.Register<IRelationManager, RelationManager>();
        }
    }
}
