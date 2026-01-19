using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.UI.WPF.Base.ActionBar;
using Fateblade.Components.UI.WPF.ViewModelMapper.Contract;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Fateblade.Alexandria.UI.WPF.Base.Modules
{
    public class AlexandriaModuleLoader
    {
        private readonly IContainerProvider _containerProvider;
        private readonly IContainerRegistry _containerRegistry;
        private readonly IGroupingActionMenuBarManager _actionBarManager;
        private readonly IEventBroker _eventBroker;
        private readonly IViewModelDataTemplateMapper _dataTemplateMapper;
        private readonly IViewModelResourceKeyMapper _resourceKeyMapper;

        public AlexandriaModuleLoader(IContainerRegistry containerRegistry, IContainerProvider containerProvider)
        {
            _containerRegistry = containerRegistry;
            _containerProvider = containerProvider;

            _actionBarManager = containerProvider.Resolve<IGroupingActionMenuBarManager>();
            _eventBroker = containerProvider.Resolve<IEventBroker>();
            _dataTemplateMapper = containerProvider.Resolve<IViewModelDataTemplateMapper>();
            _resourceKeyMapper = containerProvider.Resolve<IViewModelResourceKeyMapper>();
        }

        public void Load(IEnumerable<IAlexandriaModule> modules)
        {
            var modulesToLoad = modules?.ToList() ?? throw new ArgumentException(nameof(modules));

            foreach (var alexandriaModule in modulesToLoad)
            {
                alexandriaModule.RegisterTypes(_containerRegistry);

                alexandriaModule.AddResources();

                alexandriaModule.AddCommands(_actionBarManager, _eventBroker);

                alexandriaModule.RegisterViewModelMappings(_dataTemplateMapper, _resourceKeyMapper);

                alexandriaModule.OnInitialized(_containerProvider);
            }
        }

        public void LoadFromDirectory(string directoyPath)
        {
            var files = Directory.GetFiles(directoyPath, "*.dll");
            var foundModules = new List<IAlexandriaModule>();

            foreach (var dllfile in files/*.Where(fileName=>fileName.EndsWith(".dll"))*/)
            {
                var assembly = Assembly.LoadFile(dllfile);
                var alexandriaModuleType = assembly.ExportedTypes.FirstOrDefault(
                    type => type.GetInterfaces().Any(t => t == typeof(IAlexandriaModule)));

                if (alexandriaModuleType != null)
                {
                    IAlexandriaModule alexandriaModule = (IAlexandriaModule)Activator.CreateInstance(alexandriaModuleType);
                    foundModules.Add(alexandriaModule);
                }
            }

            Load(foundModules);
        }
    }

    public class AlexandriaResourceLoader
    {

    }
}
