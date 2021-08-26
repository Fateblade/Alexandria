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
}