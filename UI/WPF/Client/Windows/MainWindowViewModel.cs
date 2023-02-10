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


        private ObservableCollection<GroupingIconActionMenuBarCommand> _availableMenuActions;
        public ObservableCollection<GroupingIconActionMenuBarCommand> AvailableMenuActions
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
            
            AvailableMenuActions = new ObservableCollection<GroupingIconActionMenuBarCommand>()
            {
                new() {Action = new DelegateCommand(addAdditionalMenuItem) , GroupIconName= "Default", IconName = "Default", DisplayName = "Group 1 Menu Item", GroupName = "Group 1"},
                new() {Action = new DelegateCommand(addAdditionalMenuItem) , GroupIconName= "Default", IconName = "Default", DisplayName = "Group 1 Menu Item", GroupName = "Group 1"},
                new() {Action = new DelegateCommand(addAdditionalMenuItem) , GroupIconName= "Default", IconName = "Default", DisplayName = "Group 2 Menu Item", GroupName = "Group 2"},
                new() {Action = new DelegateCommand(addAdditionalMenuItem) , GroupIconName= "Default", IconName = "Default", DisplayName = "Group 2 Menu Item", GroupName = "Group 2"},
                new() {Action = new DelegateCommand(addAdditionalMenuItem) , GroupIconName= "Default", IconName = "Default", DisplayName = "Group 3 Menu Item", GroupName = "Group 3"},
                new() {Action = new DelegateCommand(addAdditionalMenuItem) , GroupIconName= "Default", IconName = "Default", DisplayName = "Group 3 Menu Item", GroupName = "Group 3"},
                new() {Action = new DelegateCommand(addAdditionalMenuItem) , GroupIconName= "Default", IconName = "Default", DisplayName = "Group 4 Menu Item", GroupName = "Group 4"},
                new() {Action = new DelegateCommand(addAdditionalMenuItem) , GroupIconName= "Default", IconName = "Default", DisplayName = "Group 4 Menu Item", GroupName = "Group 4"},
                new() {Action = new DelegateCommand(addAdditionalMenuItem) , GroupIconName= "Default", IconName = "Default", DisplayName = "Group 5 Menu Item", GroupName = "Group 5"},
                new() {Action = new DelegateCommand(addAdditionalMenuItem) , GroupIconName= "Default", IconName = "Default", DisplayName = "Group 5 Menu Item", GroupName = "Group 5"}
            };

            AvailableMenuActions.Add(new() { Action = new DelegateCommand(addAdditionalMenuItem), GroupIconName= "Default", IconName = "Default", DisplayName = "Group 6 Menu Item", GroupName = "Group 6" });
            AvailableMenuActions.Add(new() { Action = new DelegateCommand(addAdditionalMenuItem), GroupIconName = "Default", IconName = "Default", DisplayName = "Group 6 Menu Item", GroupName = "Group 6" });
        }

        private void addAdditionalMenuItem()
        {
            AvailableMenuActions.Add(new() { Action = new DelegateCommand(addAdditionalMenuItem), GroupIconName = "Default", IconName = "Default", DisplayName = "Addded from Commmand to Group 7", GroupName = "Group 7" });
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

        public void AddMenuBarCommand(GroupingIconActionMenuBarCommand command)
        {
            AvailableMenuActions.Add(command);
        }

        public void RemoveMenuBarCommand(GroupingIconActionMenuBarCommand command)
        {
            AvailableMenuActions.Remove(command);
        }
    }
}
