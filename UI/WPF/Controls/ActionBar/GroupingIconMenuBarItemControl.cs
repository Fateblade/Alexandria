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

        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register(nameof(IsSelected), typeof(bool), typeof(GroupingIconMenuBarItemControl), new PropertyMetadata(false));


    }
}
