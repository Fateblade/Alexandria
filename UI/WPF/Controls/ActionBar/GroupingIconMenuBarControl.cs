using System;
using System.Collections.Generic;
using Fateblade.Alexandria.UI.WPF.Base.ActionBar;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using Prism.Commands;

namespace Fateblade.Alexandria.UI.WPF.Controls.ActionBar
{
    public class GroupingIconMenuBarControl : Control
    {
        private readonly Dictionary<string, (GroupingActionMenuBarCommand groupActionCommand, List<GroupingActionMenuBarCommand> actions)> _groupedActionMenuBarCommands= new();

        public ObservableCollection<GroupingActionMenuBarCommand> MenuBarActions
        {
            get => (ObservableCollection<GroupingActionMenuBarCommand>)GetValue(MenuBarActionsProperty);
            set => SetValue(MenuBarActionsProperty, value);
        }
        public static readonly DependencyProperty MenuBarActionsProperty =
            DependencyProperty.Register(
                nameof(MenuBarActions), typeof(ObservableCollection<GroupingActionMenuBarCommand>),
                typeof(GroupingIconMenuBarControl), new PropertyMetadata(default, onAllMenuBarActionsChanged));

        public ObservableCollection<GroupingActionMenuBarCommand> MenuBarDefaultGroupActions
        {
            get => (ObservableCollection<GroupingActionMenuBarCommand>)GetValue(MenuBarDefaultGroupActionsProperty);
            private set => SetValue(MenuBarDefaultGroupActionsProperty, value);
        }
        public static readonly DependencyProperty MenuBarDefaultGroupActionsProperty =
            DependencyProperty.Register(nameof(MenuBarDefaultGroupActions), typeof(ObservableCollection<GroupingActionMenuBarCommand>), 
                typeof(GroupingIconMenuBarControl), new PropertyMetadata(default));

        public ObservableCollection<GroupingActionMenuBarCommand> MenuBarBottomGroupActions
        {
            get => (ObservableCollection<GroupingActionMenuBarCommand>)GetValue(MenuBarBottomGroupActionsProperty);
            private set => SetValue(MenuBarBottomGroupActionsProperty, value);
        }
        public static readonly DependencyProperty MenuBarBottomGroupActionsProperty =
            DependencyProperty.Register(nameof(MenuBarBottomGroupActions), typeof(ObservableCollection<GroupingActionMenuBarCommand>),
                typeof(GroupingIconMenuBarControl), new PropertyMetadata(default));

        public GroupingActionMenuBarCommand SelectedGroup
        {
            get => (GroupingActionMenuBarCommand)GetValue(SelectedGroupProperty);
            set => SetValue(SelectedGroupProperty, value);
        }
        public static readonly DependencyProperty SelectedGroupProperty =
            DependencyProperty.Register(nameof(SelectedGroup), typeof(GroupingActionMenuBarCommand), typeof(GroupingIconMenuBarControl), new PropertyMetadata(default));

        public ObservableCollection<GroupingActionMenuBarCommand> MenuBarActionsOfSelectedGroup
        {
            get => (ObservableCollection<GroupingActionMenuBarCommand>)GetValue(MenuBarActionsOfSelectedGroupProperty);
            private set => SetValue(MenuBarActionsOfSelectedGroupProperty, value);
        }
        public static readonly DependencyProperty MenuBarActionsOfSelectedGroupProperty =
            DependencyProperty.Register(nameof(MenuBarActionsOfSelectedGroup), typeof(ObservableCollection<GroupingActionMenuBarCommand>),
                typeof(GroupingIconMenuBarControl), new PropertyMetadata(default));


        private static void onAllMenuBarActionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GroupingIconMenuBarControl actionMenuBarControl = (GroupingIconMenuBarControl)d;
            ObservableCollection<GroupingActionMenuBarCommand> oldValue = (ObservableCollection<GroupingActionMenuBarCommand>)e.OldValue;
            ObservableCollection<GroupingActionMenuBarCommand> newValue = (ObservableCollection<GroupingActionMenuBarCommand>)e.NewValue;

            actionMenuBarControl.OnMenuBarActionsChanged(oldValue, newValue);
        }

        protected virtual void OnMenuBarActionsChanged(ObservableCollection<GroupingActionMenuBarCommand> oldValue, ObservableCollection<GroupingActionMenuBarCommand> newValue)
        {
            if (oldValue != null)
            {
                oldValue.CollectionChanged-= MenuBarActions_CollectionChanged;
            }

            if (newValue != null)
            {
                newValue.CollectionChanged += MenuBarActions_CollectionChanged;
                ResetAndGroupAllActionMenuBarItems();
            }
        }

        private void ResetAndGroupAllActionMenuBarItems()
        {
            SelectedGroup = null;
            MenuBarBottomGroupActions = new ObservableCollection<GroupingActionMenuBarCommand>();
            MenuBarDefaultGroupActions = new ObservableCollection<GroupingActionMenuBarCommand>();
            MenuBarActionsOfSelectedGroup = null;
            _groupedActionMenuBarCommands.Clear();

            foreach (var menuBarAction in MenuBarActions)
            {
                AddToGroupedActionMenuBarItems(menuBarAction);
            }
        }

        private void addNewGroupIfNotExists(GroupingActionMenuBarCommand menuBarAction)
        {
            if (_groupedActionMenuBarCommands.ContainsKey(menuBarAction.GroupInfo.GroupName)) return;

            GroupingActionMenuBarCommand groupActionCommand;

            if (menuBarAction.GroupInfo.DisplayType == GroupDisplayType.Text)
            {
                groupActionCommand = new GroupingActionMenuBarCommand()
                {
                    DisplayName = menuBarAction.GroupInfo.GroupDisplayInfo,
                    GroupInfo = menuBarAction.GroupInfo,
                    CommandParameter = menuBarAction.GroupInfo.GroupName,
                    Command = new DelegateCommand<string>(switchToGroup)
                };
            }
            else if (menuBarAction.GroupInfo.DisplayType == GroupDisplayType.Lombard)
            {
                groupActionCommand = new GroupingLombardActionMenuBarCommand()
                {
                    GroupInfo = menuBarAction.GroupInfo,
                    GlyphCode = menuBarAction.GroupInfo.GroupDisplayInfo,
                    DisplayName = menuBarAction.GroupInfo.GroupName,
                    CommandParameter = menuBarAction.GroupInfo.GroupName,
                    Command = new DelegateCommand<string>(switchToGroup)
                };
            }
            else if (menuBarAction.GroupInfo.DisplayType == GroupDisplayType.Icon)
            {
                groupActionCommand = new GroupingIconActionMenuBarCommand()
                {
                    GroupInfo = menuBarAction.GroupInfo,
                    IconName = menuBarAction.GroupInfo.GroupDisplayInfo,
                    DisplayName = menuBarAction.GroupInfo.GroupName,
                    CommandParameter = menuBarAction.GroupInfo.GroupName,
                    Command = new DelegateCommand<string>(switchToGroup)
                };
            }
            else
            {
                throw new NotImplementedException($"Display Type '{menuBarAction.GroupInfo.DisplayType}' is not implemented");
            }
            
            _groupedActionMenuBarCommands[menuBarAction.GroupInfo.GroupName] = (groupActionCommand, new List<GroupingActionMenuBarCommand>());

            if (menuBarAction.GroupInfo.Placement == GroupingPlacement.Standard)
            {
                MenuBarDefaultGroupActions.Add(groupActionCommand);
            }
            else
            {
                MenuBarBottomGroupActions.Add(groupActionCommand);
            }
            
        }

        private void switchToGroup(string groupName)
        {
            SelectedGroup = _groupedActionMenuBarCommands[groupName].groupActionCommand;

            MenuBarActionsOfSelectedGroup =
                new ObservableCollection<GroupingActionMenuBarCommand>(_groupedActionMenuBarCommands[groupName]
                    .actions);
        }

        private void MenuBarActions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e == null) throw new ArgumentException("Expected event args to exist",nameof(e));

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (e.NewItems == null) throw new ArgumentException("Expected event args to have new items on add action", nameof(e.NewItems));

                foreach (GroupingIconActionMenuBarCommand newCmd in e.NewItems)
                {
                    AddToGroupedActionMenuBarItems(newCmd);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                if (e.OldItems == null) throw new ArgumentException("Expected event args to have old items on remove action", nameof(e.OldItems));

                foreach (GroupingIconActionMenuBarCommand newCmd in e.OldItems)
                {
                    RemoveFromGroupedActionMenuBarItems(newCmd);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                throw new NotImplementedException();
            }
        }

        protected void AddToGroupedActionMenuBarItems(GroupingActionMenuBarCommand newCmd)
        {
            addNewGroupIfNotExists(newCmd);

            _groupedActionMenuBarCommands[newCmd.GroupInfo.GroupName].actions.Add(newCmd);
            if (newCmd.GroupInfo.GroupName == SelectedGroup?.DisplayName)
            {
                MenuBarActionsOfSelectedGroup.Add(newCmd);
            }
        }

        protected void RemoveFromGroupedActionMenuBarItems(GroupingActionMenuBarCommand newCmd)
        {
            var groupInfo = _groupedActionMenuBarCommands[newCmd.GroupInfo.GroupName];
            var isOfSelectedGroup = SelectedGroup?.DisplayName == newCmd.GroupInfo.GroupName;

            groupInfo.actions.Remove(newCmd);
            if (isOfSelectedGroup)
            {
                MenuBarActionsOfSelectedGroup.Remove(newCmd);
            }

            if (groupInfo.actions.Count == 0)
            {
                _groupedActionMenuBarCommands.Remove(newCmd.GroupInfo.GroupName);
                if (isOfSelectedGroup)
                {
                    SelectedGroup = null;
                    MenuBarActionsOfSelectedGroup = null;
                }
            }
        }

    }
}
