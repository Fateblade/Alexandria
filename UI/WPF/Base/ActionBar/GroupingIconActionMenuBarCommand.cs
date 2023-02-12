using System.Windows.Input;

namespace Fateblade.Alexandria.UI.WPF.Base.ActionBar;

public class GroupingActionMenuBarCommand
{
    public string DisplayName { get; set; }
    public GroupInfo GroupInfo { get; set; }
    public ICommand Command { get; set; }
}

public enum GroupingPlacement
{
    Standard,
    Bottom
}

public class GroupInfo
{
    public string GroupName { get; set; }
    /// <summary>
    /// contains icon name, glyph code or display name depending on the <see cref="DisplayType"/>
    /// </summary>
    public string GroupDisplayInfo { get; set; }
    public GroupDisplayType DisplayType { get; set; }
    public GroupingPlacement Placement { get; set; }
}

public enum GroupDisplayType
{
    Text,
    Lombard,
    Icon
}

public class GroupingIconActionMenuBarCommand : GroupingActionMenuBarCommand
{
    public string IconName { get; set; }
}

public class GroupingLombardActionMenuBarCommand : GroupingActionMenuBarCommand
{
    /// <summary>
    /// Hexadezimal code that represents the lombard letter
    /// </summary>
    public string GlyphCode { get; set; }
}