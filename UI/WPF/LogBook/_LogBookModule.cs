using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.UI.WPF.Base.ActionBar;
using Fateblade.Alexandria.UI.WPF.Base.Messages;
using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;

namespace Fateblade.Alexandria.UI.WPF.Modules.LogBook
{
    public class LogBookModule : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var actionBarManager = containerProvider.Resolve<IGroupingActionMenuBarManager>();
            var eventBroker = containerProvider.Resolve<IEventBroker>();

            var logBookGroupInfo = new GroupInfo()
            {
                DisplayType = GroupDisplayType.Lombard,
                GroupDisplayInfo = "Logbuch",
                GroupName = "Logbuch",
                Placement = GroupingPlacement.Standard
            };


            actionBarManager.AddMenuBarCommand(new GroupingLombardActionMenuBarCommand()
            {
                Command = new DelegateCommand(()=>eventBroker.Raise(new ShowExistingPageOrchestrationInfo())),
                CommandParameter = null,
                DisplayName = "Logbuch öffnen/erstellen",
                GlyphCode = "O",
                GroupInfo = logBookGroupInfo
            });
        }
    }
}
