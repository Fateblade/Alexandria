using System.Collections.Generic;
using Fateblade.Alexandria.UI.WPF.Base.ActionBar.Exceptions;

namespace Fateblade.Alexandria.UI.WPF.Base.ActionBar
{
    public class ActionMenuBarManager : IActionMenuBarManager
    {
        protected List<ActionMenuBarCommand> CommandBackup { get; } = new();
        protected IActionMenuBarProvider RegisteredProvider;

        public void AddMenuBarCommand(ActionMenuBarCommand command)
        {
            if (RegisteredProvider == null)
            {
                CommandBackup.Add(command);
            }
            else
            {
                RegisteredProvider.AddMenuBarCommand(command);
            }
        }

        public void RemoveMenuBarCommand(ActionMenuBarCommand command)
        {
            if (RegisteredProvider == null)
            {
                CommandBackup.Remove(command);
            }
            else
            {
                RegisteredProvider.RemoveMenuBarCommand(command);
            }
        }

        public void RegisterActionMenuBarProvider(IActionMenuBarProvider provider)
        {
            if (RegisteredProvider != null)
            {
                throw new ActionBarProviderAlreadyRegisteredException(
                    "There is already a provider registered for the action menu bar");
            }

            RegisteredProvider = provider;

            foreach (ActionMenuBarCommand actionMenuBarCommand in CommandBackup)
            {
                RegisteredProvider.AddMenuBarCommand(actionMenuBarCommand);
            }

            CommandBackup.Clear();
        }
    }


    public class GroupingActionMenuBarManager : IGroupingActionMenuBarManager
    {
        protected List<GroupingActionMenuBarCommand> CommandBackup { get; } = new();
        protected IGroupingActionMenuBarProvider RegisteredProvider;

        public void AddMenuBarCommand(GroupingActionMenuBarCommand command)
        {
            if (RegisteredProvider == null)
            {
                CommandBackup.Add(command);
            }
            else
            {
                RegisteredProvider.AddMenuBarCommand(command);
            }
        }

        public void RemoveMenuBarCommand(GroupingActionMenuBarCommand command)
        {
            if (RegisteredProvider == null)
            {
                CommandBackup.Remove(command);
            }
            else
            {
                RegisteredProvider.RemoveMenuBarCommand(command);
            }
        }

        public void RegisterActionMenuBarProvider(IGroupingActionMenuBarProvider provider)
        {
            if (RegisteredProvider != null)
            {
                throw new ActionBarProviderAlreadyRegisteredException(
                    "There is already a provider registered for the action menu bar");
            }

            RegisteredProvider = provider;

            foreach (GroupingActionMenuBarCommand actionMenuBarCommand in CommandBackup)
            {
                RegisteredProvider.AddMenuBarCommand(actionMenuBarCommand);
            }

            CommandBackup.Clear();
        }
    }
}
