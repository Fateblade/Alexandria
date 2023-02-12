﻿namespace Fateblade.Alexandria.UI.WPF.Base.ActionBar
{
    /// <summary>
    /// use this interface to add or remove action bar commands or register a provider
    /// </summary>
    public interface IActionMenuBarManager
    {
        void AddMenuBarCommand(ActionMenuBarCommand command);
        void RemoveMenuBarCommand(ActionMenuBarCommand command);
        void RegisterActionMenuBarProvider(IActionMenuBarProvider provider);
    }

    /// <summary>
    /// use this interface to add or remove action bar commands or register a provider
    /// </summary>
    public interface IGroupingActionMenuBarManager
    {
        void AddMenuBarCommand(GroupingActionMenuBarCommand command);
        void RemoveMenuBarCommand(GroupingActionMenuBarCommand command);
        void RegisterActionMenuBarProvider(IGroupingActionMenuBarProvider provider);
    }
}
