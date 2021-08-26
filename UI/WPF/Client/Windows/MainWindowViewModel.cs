using Fateblade.Alexandria.UI.WPF.Base.Messages;
using Fateblade.Components.Logic.Foundation.Orchestration.Contract;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using Fateblade.Alexandria.UI.WPF.Base.ActionBar;

namespace Fateblade.Alexandria.UI.WPF.Client.Windows
{
    class MainWindowViewModel : BindableBase, IOrchestrationHandler<ShowDialogOrchestrationInfo>, IOrchestrationHandler<ShowPageOrchestrationInfo>, IActionMenuBarProvider
    {
        private Action<BindableBase> _handleCurrentPageClosed;
        private Action<BindableBase> _handleCurrentDialogClosed;


        private ObservableCollection<ActionMenuBarCommand> _availableMenuActions;
        public ObservableCollection<ActionMenuBarCommand> AvailableMenuActions
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
            menuBarManager.RegisterActionMenuBarProvider(this);
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

        public void AddMenuBarCommand(ActionMenuBarCommand command)
        {
            AvailableMenuActions.Add(command);
        }

        public void RemoveMenuBarCommand(ActionMenuBarCommand command)
        {
            AvailableMenuActions.Remove(command);
        }
    }
}
