using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fateblade.Alexandria.UI.WPF.Base.UiBehaviour
{
    public static class TextBoxEnterPressedCommand
    {
        public static ICommand GetEnterPressedCommand(DependencyObject target)
        {
            return (ICommand)target.GetValue(EnterPressedCommandProperty);
        }

        public static void SetEnterPressedCommand(DependencyObject target, ICommand value)
        {
            target.SetValue(EnterPressedCommandProperty, value);
        }

        public static readonly DependencyProperty EnterPressedCommandProperty =
            DependencyProperty.RegisterAttached(
                "EnterPressedCommand",
                typeof(ICommand),
                typeof(TextBoxEnterPressedCommand),
                new PropertyMetadata(null, OnEnterKeyPressedCommandChanged));

        private static void OnEnterKeyPressedCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Control control = (Control)d;
            ICommand newCmd = (ICommand)e.NewValue;

            if (newCmd == null) return;

            control.KeyUp += (sender, args) =>
            {
                if (args.Key == Key.Enter)
                {
                    control.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
                    if (newCmd?.CanExecute(null)==true)
                    {
                        newCmd.Execute(null);
                    }
                }
            };

        }
    }
}
