using Fateblade.Components.UI.WPF.ViewModelMapper.Contract;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Controls;

namespace Fateblade.Alexandria.UI.WPF.Client.Views
{
    public class ViewModelTemplateSelector : DataTemplateSelector
    {
        private readonly IViewModelMapper _viewModelMapper;

        public ViewModelTemplateSelector()
        {
            _viewModelMapper = (IViewModelMapper)((App)Application.Current).Container.Resolve(typeof(IViewModelMapper));
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement frameworkElement = container as FrameworkElement;

            if (item is BindableBase)
            {
                return _viewModelMapper.GetMapping(item.GetType());
            }

            return base.SelectTemplate(item, container);
        }
    }
}
