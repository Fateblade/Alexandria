using System.Windows.Controls;
using System.Windows.Input;

namespace Fateblade.Alexandria.UI.WPF.Controls.Buttons
{
    public class SearchTextBox : TextBox
    {
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.Key == Key.Enter)
            {
                GetBindingExpression(TextProperty)?.UpdateSource();
            }

            if (e.Key == Key.Escape)
            {
                MoveFocus(new TraversalRequest(FocusNavigationDirection.Up));
            }
        }
    }
}
