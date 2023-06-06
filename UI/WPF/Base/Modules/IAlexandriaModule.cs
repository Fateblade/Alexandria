using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.UI.WPF.Base.ActionBar;
using Fateblade.Components.UI.WPF.ViewModelMapper.Contract;
using Prism.Modularity;

namespace Fateblade.Alexandria.UI.WPF.Base.Modules
{
    public interface IAlexandriaModule : IModule
    {
        void AddResources();

        void RegisterViewModelMappings(IViewModelDataTemplateMapper dataTemplateMapper, IViewModelResourceKeyMapper resourceKeyMapper);

        void AddCommands(IGroupingActionMenuBarManager menuBarManager, IEventBroker eventBroker);
    }
}
