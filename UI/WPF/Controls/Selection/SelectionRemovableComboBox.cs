using System.Windows.Controls;
using System.Windows.Input;

namespace Fateblade.Alexandria.UI.WPF.Controls.Selection
{
    public class SelectionRemovableComboBox : ComboBox
    {
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                SelectedItem = null;
                e.Handled = true;
            }

            base.OnKeyUp(e);
        }
    }
}
