using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement
{
    public class MetaManagementComponentActivator : IComponentActivator
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
            kernel.Register<IAdventureManager, AdventureManager>();
            kernel.Register<ICampaignManager, CampaignManager>();
            kernel.Register<IEncounterManager, EncounterManager>();
            kernel.Register<ILinkManager, LinkManager>();
            kernel.Register<INoteManager, NoteManager>();
            kernel.Register<IPlayerManager, PlayerManager>();
            kernel.Register<IRewardManager, RewardManager>();
            kernel.Register<ISessionManager, SessionManager>();
            kernel.Register<IStageManager, StageManager>();
            kernel.Register<ITagManager, TagManager>();
            kernel.Register<ITextInfoManager, TextInfoManager>();
        }
    }
}
