namespace Fateblade.Alexandria.UI.WPF.Base.ActionBar
{
    /// <summary>
    /// provides actual ui handling of action menu bar commands
    /// </summary>
    public interface IActionMenuBarProvider
    {
        void AddMenuBarCommand(ActionMenuBarCommand command);
        void RemoveMenuBarCommand(ActionMenuBarCommand command);
    }

    /// <summary>
    /// provides actual ui handling of action menu bar commands
    /// </summary>
    public interface IGroupingActionMenuBarProvider
    {
        void AddMenuBarCommand(GroupingIconActionMenuBarCommand command);
        void RemoveMenuBarCommand(GroupingIconActionMenuBarCommand command);
    }
}