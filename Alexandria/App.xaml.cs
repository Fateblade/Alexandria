using ACI.Base.Logging;
using Alexandrian.Base.Logging;
using Prism.Ioc;
using Prism.Logging;
using Prism.Unity;
using System.Windows;

namespace Alexandria
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        //private Bootstrapper _bootstrapper;

        public App()
        {
            
        }
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var logger = new MultiLogger();
            logger.AddLogger(new DebugConsoleLogger());

            containerRegistry.RegisterInstance<ILoggerFacade>(logger);
        }
    }
}
