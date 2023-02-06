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
        private readonly Dictionary<string, (GroupIconActionMenuBarCommand groupActionCommand, List<GroupingIconActionMenuBarCommand> actions)> _groupedActionMenuBarCommands= new();

        public ObservableCollection<GroupingIconActionMenuBarCommand> MenuBarActions
        {
            get => (ObservableCollection<GroupingIconActionMenuBarCommand>)GetValue(MenuBarActionsProperty);
            set => SetValue(MenuBarActionsProperty, value);
        }
        public static readonly DependencyProperty MenuBarActionsProperty =
            DependencyProperty.Register(
                nameof(MenuBarActions), typeof(ObservableCollection<GroupingIconActionMenuBarCommand>),
                typeof(GroupingIconMenuBarControl), new PropertyMetadata(default, new PropertyChangedCallback(onAllMenuBarActionsChanged)));

        public ObservableCollection<GroupIconActionMenuBarCommand> MenuBarGroupActions
        {
            get => (ObservableCollection<GroupIconActionMenuBarCommand>)GetValue(MenuBarGroupActionsProperty);
            private set => SetValue(MenuBarGroupActionsProperty, value);
        }
        public static readonly DependencyProperty MenuBarGroupActionsProperty =
            DependencyProperty.Register(nameof(MenuBarGroupActions), typeof(ObservableCollection<GroupIconActionMenuBarCommand>), 
                typeof(GroupingIconMenuBarControl), new PropertyMetadata(default));

        public GroupIconActionMenuBarCommand SelectedGroup
        {
            get => (GroupIconActionMenuBarCommand)GetValue(SelectedGroupProperty);
            set => SetValue(SelectedGroupProperty, value);
        }
        public static readonly DependencyProperty SelectedGroupProperty =
            DependencyProperty.Register(nameof(SelectedGroup), typeof(GroupIconActionMenuBarCommand), typeof(GroupingIconMenuBarControl), new PropertyMetadata(default));

        public ObservableCollection<GroupingIconActionMenuBarCommand> MenuBarActionsOfSelectedGroup
        {
            get => (ObservableCollection<GroupingIconActionMenuBarCommand>)GetValue(MenuBarActionsOfSelectedGroupProperty);
            private set => SetValue(MenuBarActionsOfSelectedGroupProperty, value);
        }
        public static readonly DependencyProperty MenuBarActionsOfSelectedGroupProperty =
            DependencyProperty.Register(nameof(MenuBarActionsOfSelectedGroup), typeof(ObservableCollection<GroupingIconActionMenuBarCommand>),
                typeof(GroupingIconMenuBarControl), new PropertyMetadata(default));


        private static void onAllMenuBarActionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GroupingIconMenuBarControl actionMenuBarControl = (GroupingIconMenuBarControl)d;
            ObservableCollection<GroupingIconActionMenuBarCommand> oldValue = (ObservableCollection<GroupingIconActionMenuBarCommand>)e.OldValue;
            ObservableCollection<GroupingIconActionMenuBarCommand> newValue = (ObservableCollection<GroupingIconActionMenuBarCommand>)e.NewValue;

            actionMenuBarControl.OnMenuBarActionsChanged(oldValue, newValue);
        }

        protected virtual void OnMenuBarActionsChanged(ObservableCollection<GroupingIconActionMenuBarCommand> oldValue, ObservableCollection<GroupingIconActionMenuBarCommand> newValue)
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
            MenuBarGroupActions = new ObservableCollection<GroupIconActionMenuBarCommand>();
            MenuBarActionsOfSelectedGroup = null;
            _groupedActionMenuBarCommands.Clear();


            foreach (var menuBarAction in MenuBarActions)
            {
                AddToGroupedActionMenuBarItems(menuBarAction);
                
            }
        }

        private void addNewGroupIfNotExists(GroupingIconActionMenuBarCommand menuBarAction)
        {
            if (_groupedActionMenuBarCommands.ContainsKey(menuBarAction.GroupName)) return;

            var groupActionCommand = new GroupIconActionMenuBarCommand
            {
                IconResourcePath = menuBarAction.IconResourcePath,
                DisplayName = menuBarAction.GroupName,
                Action = new DelegateCommand<string>(switchToGroup)
            };

            _groupedActionMenuBarCommands[menuBarAction.GroupName] = (groupActionCommand, new List<GroupingIconActionMenuBarCommand>());
            MenuBarGroupActions.Add(groupActionCommand);
        }

        private void switchToGroup(string groupName)
        {
            SelectedGroup = _groupedActionMenuBarCommands[groupName].groupActionCommand;

            MenuBarActionsOfSelectedGroup =
                new ObservableCollection<GroupingIconActionMenuBarCommand>(_groupedActionMenuBarCommands[groupName]
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

        protected void AddToGroupedActionMenuBarItems(GroupingIconActionMenuBarCommand newCmd)
        {
            addNewGroupIfNotExists(newCmd);

            _groupedActionMenuBarCommands[newCmd.GroupName].actions.Add(newCmd);
            if (newCmd.GroupName == SelectedGroup.DisplayName)
            {
                MenuBarActionsOfSelectedGroup.Add(newCmd);
            }
        }

        protected void RemoveFromGroupedActionMenuBarItems(GroupingIconActionMenuBarCommand newCmd)
        {
            var groupInfo = _groupedActionMenuBarCommands[newCmd.GroupName];
            var isOfSelectedGroup = SelectedGroup?.DisplayName == newCmd.GroupName;

            groupInfo.actions.Remove(newCmd);
            if (isOfSelectedGroup)
            {
                MenuBarActionsOfSelectedGroup.Remove(newCmd);
            }

            if (groupInfo.actions.Count == 0)
            {
                _groupedActionMenuBarCommands.Remove(newCmd.GroupName);
                if (isOfSelectedGroup)
                {
                    SelectedGroup = null;
                    MenuBarActionsOfSelectedGroup = null;
                }
            }
        }

    }
}
