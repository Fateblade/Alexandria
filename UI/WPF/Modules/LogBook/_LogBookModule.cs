using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.UI.WPF.Base.ActionBar;
using Fateblade.Alexandria.UI.WPF.Base.Messages;
using Fateblade.Alexandria.UI.WPF.Base.Modules;
using Fateblade.Alexandria.UI.WPF.Modules.LogBook.Messages;
using Fateblade.Alexandria.UI.WPF.Modules.LogBook.Views;
using Fateblade.Components.UI.WPF.ViewModelMapper.Contract;
using Prism.Commands;
using Prism.Ioc;

namespace Fateblade.Alexandria.UI.WPF.Modules.LogBook
{
    // TODO: implement extended IAlexandriaModule that includes common things
    public class LogBookModule : IAlexandriaModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            

        }

        public void AddResources()
        {
            throw new System.NotImplementedException();
        }

        public void RegisterViewModelMappings(IViewModelDataTemplateMapper dataTemplateMapper,
            IViewModelResourceKeyMapper resourceKeyMapper)
        {
            throw new System.NotImplementedException();
        }

        public void AddCommands(IGroupingActionMenuBarManager menuBarManager, IEventBroker eventBroker)
        {
            var logBookGroupInfo = new GroupInfo()
            {
                DisplayType = GroupDisplayType.Lombard,
                GroupDisplayInfo = "L",
                GroupName = "Logbuch",
                Placement = GroupingPlacement.Standard
            };

            menuBarManager.AddMenuBarCommand(new GroupingLombardActionMenuBarCommand()
            {
                Command = new DelegateCommand(() => eventBroker.Raise(new ShowPageOrchestrationInfo(typeof(SelectCreateLogbookViewModel)))),
                CommandParameter = null,
                DisplayName = "Logbuch öffnen/erstellen",
                GlyphCode = "O",
                GroupInfo = logBookGroupInfo
            });

            menuBarManager.AddMenuBarCommand(new GroupingLombardActionMenuBarCommand()
            {
                Command = new DelegateCommand(() => eventBroker.Raise(new ShowPageOrchestrationInfo(typeof(ViewLogbookViewModel)))),
                CommandParameter = null,
                DisplayName = "Logbuch ansehen",
                GlyphCode = "O",
                GroupInfo = logBookGroupInfo
            });

            menuBarManager.AddMenuBarCommand(new GroupingLombardActionMenuBarCommand()
            {
                Command = new DelegateCommand(() => eventBroker.Raise(new ShowPageOrchestrationInfo(typeof(EditLogbookEntryViewModel)))),
                CommandParameter = null,
                DisplayName = "Eintrag hinzufügen",
                GlyphCode = "O",
                GroupInfo = logBookGroupInfo
            });

            menuBarManager.AddMenuBarCommand(new GroupingLombardActionMenuBarCommand()
            {
                Command = new DelegateCommand(
                    () =>
                    {
                        eventBroker.Raise(new SaveAndCloseCurrentLogbookMessage());
                        eventBroker.Raise(new ShowPageOrchestrationInfo(typeof(SelectCreateLogbookViewModel)));
                    }
                        ),
                CommandParameter = null,
                DisplayName = "Logbuch schließen",
                GlyphCode = "O",
                GroupInfo = logBookGroupInfo
            });
        }
    }
}
