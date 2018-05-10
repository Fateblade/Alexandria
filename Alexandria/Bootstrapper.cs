using System.Windows;
using Prism.Logging;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace Alexandria
{
    internal class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }

        protected override ILoggerFacade CreateLogger()
        {
            return base.CreateLogger();
        }
    }
}
