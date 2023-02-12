using Fateblade.Alexandria.UI.WPF.Base.Messages;
using Fateblade.Components.Logic.Foundation.Orchestration.Contract;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using Fateblade.Alexandria.UI.WPF.Base.ActionBar;
using Prism.Commands;

namespace Fateblade.Alexandria.UI.WPF.Client.Windows
{
    class MainWindowViewModel : BindableBase, IOrchestrationHandler<ShowDialogOrchestrationInfo>, IOrchestrationHandler<ShowPageOrchestrationInfo>, IGroupingActionMenuBarProvider
    {
        private Action<BindableBase> _handleCurrentPageClosed;
        private Action<BindableBase> _handleCurrentDialogClosed;


        private ObservableCollection<GroupingActionMenuBarCommand> _availableMenuActions;
        public ObservableCollection<GroupingActionMenuBarCommand> AvailableMenuActions
        {
            get => _availableMenuActions;
            set => SetProperty(ref _availableMenuActions, value);
        }

        private BindableBase _currentlyDisplayedPage;
        public BindableBase CurrentlyDisplayedPage
        {
            get => _currentlyDisplayedPage;
            set => SetProperty(ref _currentlyDisplayedPage, value);  
        }

        private BindableBase _currentlyDisplayedDialog;
        public BindableBase CurrentlyDisplayedDialog
        {
            get => _currentlyDisplayedDialog;
            set => SetProperty(ref _currentlyDisplayedDialog, value);
        }


        public MainWindowViewModel(IOrchestrator orchestrator, IActionMenuBarManager menuBarManager)
        {
            orchestrator.RegisterHandler((IOrchestrationHandler<ShowDialogOrchestrationInfo>) this);
            orchestrator.RegisterHandler((IOrchestrationHandler<ShowPageOrchestrationInfo>)this);
            //menuBarManager.RegisterActionMenuBarProvider(this);

            var textGroup = new GroupInfo
            {
                DisplayType = GroupDisplayType.Text,
                GroupDisplayInfo = "Text",
                GroupName = "Group 1",
                Placement = GroupingPlacement.Standard
            };
            var lombardGroup = new GroupInfo
            {
                DisplayType = GroupDisplayType.Lombard,
                GroupDisplayInfo = "L",
                GroupName = "Group 2",
                Placement = GroupingPlacement.Standard
            };
            var iconGroup = new GroupInfo
            {
                DisplayType = GroupDisplayType.Icon,
                GroupDisplayInfo = "Default",
                GroupName = "Group 3",
                Placement = GroupingPlacement.Standard
            };
            AvailableMenuActions = new ObservableCollection<GroupingActionMenuBarCommand>()
            {
                new GroupingIconActionMenuBarCommand() {Command = new DelegateCommand(addAdditionalMenuItem) ,GroupInfo=lombardGroup, IconName = "Default", DisplayName = "Group 1 Menu Item"},
                new GroupingIconActionMenuBarCommand() {Command = new DelegateCommand(addAdditionalMenuItem) ,GroupInfo=lombardGroup, IconName = "Default", DisplayName = "Group 1 Menu Item"},

                new GroupingLombardActionMenuBarCommand() {Command = new DelegateCommand(addAdditionalMenuItem) , GroupInfo=textGroup, GlyphCode = "A", DisplayName = "Group 3 Menu Item"},
                new GroupingLombardActionMenuBarCommand() {Command = new DelegateCommand(addAdditionalMenuItem) , GroupInfo=textGroup, GlyphCode = "B", DisplayName = "Group 3 Menu Item"},

                new () {Command = new DelegateCommand(addAdditionalMenuItem) ,GroupInfo=iconGroup, DisplayName = "Group 4 Menu Item"},
                new () {Command = new DelegateCommand(addAdditionalMenuItem) ,GroupInfo=iconGroup, DisplayName = "Group 4 Menu Item"},
            };
        }

        private void addAdditionalMenuItem()
        {
            AvailableMenuActions.Add(new GroupingIconActionMenuBarCommand() 
            { 
                Command = new DelegateCommand(addAdditionalMenuItem), 
                GroupInfo = new GroupInfo
            {
                DisplayType = GroupDisplayType.Text,
                GroupDisplayInfo = "Bottom",
                GroupName = "Group 4",
                Placement = GroupingPlacement.Bottom
            },
                IconName = "Default", 
                DisplayName = "Addded from Commmand to Group 7" });
        }

        public void Handle(ShowDialogOrchestrationInfo dialogOrchestrationInfo)
        {
            if (CurrentlyDisplayedDialog != null && _handleCurrentDialogClosed != null)
            {
                _handleCurrentDialogClosed.Invoke(CurrentlyDisplayedDialog);
            }

            _handleCurrentDialogClosed = dialogOrchestrationInfo.HandleDialogClosed;
            CurrentlyDisplayedDialog = dialogOrchestrationInfo.DialogViewModelToDisplay;
        }

        public void Handle(ShowPageOrchestrationInfo pageOrchestrationInfo)
        {
            if (CurrentlyDisplayedPage != null && _handleCurrentPageClosed != null)
            {
                _handleCurrentPageClosed.Invoke(CurrentlyDisplayedPage);
            }

            _handleCurrentPageClosed = pageOrchestrationInfo.HandlePageClosed;
            CurrentlyDisplayedPage = pageOrchestrationInfo.PageViewModelToDisplay;
        }

        public void AddMenuBarCommand(GroupingActionMenuBarCommand command)
        {
            AvailableMenuActions.Add(command);
        }

        public void RemoveMenuBarCommand(GroupingActionMenuBarCommand command)
        {
            AvailableMenuActions.Remove(command);
        }
    }
}
