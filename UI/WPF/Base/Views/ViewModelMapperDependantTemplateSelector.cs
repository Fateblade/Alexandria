using Fateblade.Alexandria.UI.WPF.Base.Interfaces;
using Fateblade.Components.UI.WPF.ViewModelMapper.Contract;
using System.Windows;
using System.Windows.Controls;

namespace Fateblade.Alexandria.UI.WPF.Base.Views
{
    public class ViewModelMapperDependantTemplateSelector : DataTemplateSelector
    {
        private readonly IViewModelDataTemplateMapper _templateRegistry;
        private readonly IViewModelResourceKeyMapper _resourceKeyRegistry;

        public ViewModelMapperDependantTemplateSelector()
        {
            _templateRegistry = (IViewModelDataTemplateMapper)((IContainerApp)Application.Current).Container.Resolve(typeof(IViewModelDataTemplateMapper));
            _resourceKeyRegistry = (IViewModelResourceKeyMapper)((IContainerApp)Application.Current).Container.Resolve(typeof(IViewModelResourceKeyMapper));
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return null;

            var vmType = item.GetType();
            if (_templateRegistry.HasMapping(vmType))
            {
                return (DataTemplate)Application.Current.FindResource(_templateRegistry.GetMapping(vmType));
            }

            if (_resourceKeyRegistry.HasMapping(vmType))
            {
                return (DataTemplate)Application.Current.FindResource(_resourceKeyRegistry.GetMapping(vmType));
            }

            return base.SelectTemplate(item, container);
        }
    }
}
