using System.Windows;
using System.Windows.Controls;
using Fateblade.Alexandria.UI.WPF.Base.ActionBar;

namespace Fateblade.Alexandria.UI.WPF.Controls.ActionBar
{
    internal class ActionMenuBarItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ActionMenuBarCommandTemplate { get; set; }
        public DataTemplate IconActionMenuBarCommandTemplate { get; set; }
        public DataTemplate LombardActionMenuBarCommandTemplate { get; set; }
        public DataTemplate GroupingActionMenuBarCommand { get; set; }
        public DataTemplate GroupingIconActionMenuBarCommand { get; set; }
        public DataTemplate GroupingLombardActionMenuBarCommand { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is IconActionMenuBarCommand) return IconActionMenuBarCommandTemplate;
            if (item is LombardActionMenuBarCommand) return LombardActionMenuBarCommandTemplate;
            if (item is ActionMenuBarCommand) return ActionMenuBarCommandTemplate;
            
            if (item is GroupingIconActionMenuBarCommand) return GroupingIconActionMenuBarCommand;
            if (item is GroupingLombardActionMenuBarCommand) return GroupingLombardActionMenuBarCommand;
            if (item is GroupingActionMenuBarCommand) return GroupingActionMenuBarCommand;

            return base.SelectTemplate(item, container);
        }
    }
}
