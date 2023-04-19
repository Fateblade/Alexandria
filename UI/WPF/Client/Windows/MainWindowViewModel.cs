using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.UI.WPF.Base.ActionBar;
using Fateblade.Alexandria.UI.WPF.Base.Messages;
using Fateblade.Alexandria.UI.WPF.Base.Views;
using Fateblade.Components.Logic.Foundation.Orchestration.Contract;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace Fateblade.Alexandria.UI.WPF.Client.Windows
{
    class MainWindowViewModel : HostingViewModelBase, 
        IOrchestrationHandler<ShowDialogOrchestrationInfo>, 
        IOrchestrationHandler<ShowExistingPageOrchestrationInfo>, 
        IOrchestrationHandler<ShowPageOrchestrationInfo>,
        IGroupingActionMenuBarProvider
    {
        private Action<BindableBase> _handlePageClosed;
        private Action<BindableBase> _handleDialogClosed;



        private ObservableCollection<GroupingActionMenuBarCommand> _menuBarActions;
        public ObservableCollection<GroupingActionMenuBarCommand> MenuBarActions
        {
            get => _menuBarActions;
            set => SetProperty(ref _menuBarActions, value);
        }

        private BindableBase _displayedDialog;
        public BindableBase DisplayedDialog
        {
            get => _displayedDialog;
            set => SetProperty(ref _displayedDialog, value);
        }
        


        public MainWindowViewModel(IOrchestrator orchestrator, IGroupingActionMenuBarManager menuBarManager, 
            IEventBroker eventBroker, IContainerProvider container) 
            : base(eventBroker, container, nameof(MainWindowViewModel))
        {
            orchestrator.RegisterHandler((IOrchestrationHandler<ShowDialogOrchestrationInfo>) this);
            orchestrator.RegisterHandler((IOrchestrationHandler<ShowExistingPageOrchestrationInfo>)this);
            menuBarManager.RegisterActionMenuBarProvider(this);
        }
        


        public void Handle(ShowDialogOrchestrationInfo dialogOrchestrationInfo)
        {
            if (DisplayedDialog != null && _handleDialogClosed != null)
            {
                _handleDialogClosed.Invoke(DisplayedDialog);
            }

            _handleDialogClosed = dialogOrchestrationInfo.HandleDialogClosed;
            DisplayedDialog = dialogOrchestrationInfo.DialogViewModelToDisplay;
        }

        public void Handle(ShowExistingPageOrchestrationInfo pageOrchestrationInfo)
        {
            if (DisplayedContent != null && _handlePageClosed != null)
            {
                _handlePageClosed.Invoke(DisplayedContent);
            }

            _handlePageClosed = pageOrchestrationInfo.HandlePageClosed;
            hostDirectly(pageOrchestrationInfo.PageViewModelToDisplay);
        }

        public void Handle(ShowPageOrchestrationInfo pageOrchestrationInfo)
        {
            if (DisplayedContent != null && _handlePageClosed != null)
            {
                _handlePageClosed.Invoke(DisplayedContent);
            }

            _handlePageClosed = pageOrchestrationInfo.HandlePageClosed;
            hostOrDelegateHosting(pageOrchestrationInfo.PageViewModelTypeToDisplay);
        }

        public void AddMenuBarCommand(GroupingActionMenuBarCommand command)
        {
            MenuBarActions.Add(command);
        }

        public void RemoveMenuBarCommand(GroupingActionMenuBarCommand command)
        {
            MenuBarActions.Remove(command);
        }

    }
}
