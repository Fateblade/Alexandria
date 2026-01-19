using Fateblade.Alexandria.UI.WPF.Base.ActionBar;
using Fateblade.Components.UI.WPF.ViewModelMapper.Contract;
using Prism.Ioc;
using Prism.Modularity;

namespace Fateblade.Alexandria.UI.WPF.Modules.Core
{
    public class CoreModule : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            IActionMenuBarManager actionMenuBar = containerProvider.Resolve<IActionMenuBarManager>();
            IViewModelMapper viewModelMapper = containerProvider.Resolve<IViewModelMapper>();

        }
    }
}
