using Fateblade.Alexandria.UI.WPF.Base.ActionBar;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Fateblade.Alexandria.UI.WPF.Controls.ActionBar
{
    public class ActionMenuBarControl : Control
    {
        public static readonly DependencyProperty MenuBarActionsProperty = DependencyProperty.Register(
            nameof(MenuBarActions), 
            typeof(ObservableCollection<ActionMenuBarCommand>), 
            typeof(ActionMenuBarControl), 
            new PropertyMetadata(
                default(ObservableCollection<ActionMenuBarCommand>), 
                new PropertyChangedCallback(onMenuBarActionsChanged)));

        private static void onMenuBarActionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ActionMenuBarControl actionMenuBarControl = (ActionMenuBarControl)d;
            ObservableCollection<ActionMenuBarCommand> oldValue = (ObservableCollection<ActionMenuBarCommand>)e.OldValue;
            ObservableCollection<ActionMenuBarCommand> newValue = (ObservableCollection<ActionMenuBarCommand>)e.NewValue;

            actionMenuBarControl.OnMenuBarActionsChanged(oldValue, newValue);
        }

        [Bindable(true)]
        public ObservableCollection<ActionMenuBarCommand> MenuBarActions
        {
            get => (ObservableCollection<ActionMenuBarCommand>) GetValue(MenuBarActionsProperty);
            set => SetValue(MenuBarActionsProperty, value);
        }

        protected virtual void OnMenuBarActionsChanged(ObservableCollection<ActionMenuBarCommand> oldValue, ObservableCollection<ActionMenuBarCommand> newValue)
        {

        }
    }
}
