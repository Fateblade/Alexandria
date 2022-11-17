using Prism.Ioc;
using Prism.Modularity;

namespace Alexandria.UI.WPF.Modules.CommonTranslations
{
    public class CommonTranslationModule : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IEnumTranslator, EnumTranslator>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {

        }
    }
}
