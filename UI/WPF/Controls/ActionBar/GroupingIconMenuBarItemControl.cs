using System.Windows;
using System.Windows.Controls;

namespace Fateblade.Alexandria.UI.WPF.Controls.ActionBar
{
    public class GroupingIconMenuBarItemControl : Button
    {
        public string IconName
        {
            get => (string)GetValue(IconNameProperty);
            set => SetValue(IconNameProperty, value);
        }
        public static readonly DependencyProperty IconNameProperty =
            DependencyProperty.Register(nameof(IconName), typeof(string), typeof(GroupingIconMenuBarItemControl), new PropertyMetadata(default));
    }
}
