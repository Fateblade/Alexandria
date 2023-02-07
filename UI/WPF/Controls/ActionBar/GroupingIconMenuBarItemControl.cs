using System.Windows;
using System.Windows.Controls;

namespace Fateblade.Alexandria.UI.WPF.Controls.ActionBar
{
    public class GroupingIconMenuBarItemControl : Button
    {
        public string IconResourcePath
        {
            get => (string)GetValue(IconResourcePathProperty);
            set => SetValue(IconResourcePathProperty, value);
        }
        public static readonly DependencyProperty IconResourcePathProperty =
            DependencyProperty.Register(nameof(IconResourcePath), typeof(string), typeof(GroupingIconMenuBarItemControl), new PropertyMetadata(default));
    }
}
