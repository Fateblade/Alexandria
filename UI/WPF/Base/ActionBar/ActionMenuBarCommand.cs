using System.Windows.Input;

namespace Fateblade.Alexandria.UI.WPF.Base.ActionBar
{
    public class ActionMenuBarCommand
    {
        public string DisplayName
        {
            get ;
            set ;
        }

        public ICommand Action
        {
            get ;
            set;
        }
    }

    public class IconActionMenuBarCommand : ActionMenuBarCommand
    {
        public string IconName { get; set; }
    }

    public class LombardActionMenuBarCommand : ActionMenuBarCommand
    {
        /// <summary>
        /// Hexadezimal code that represents the lombard letter
        /// </summary>
        public string GlyphCode { get; set; }
    }
}