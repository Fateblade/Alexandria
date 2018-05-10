using System.Windows;
using Prism.Logging;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Alexandrian.Base.Logging;

namespace Alexandria
{
    internal class Bootstrapper : UnityBootstrapper
    {
        private ILoggerFacade _loggerFacade;

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
            _loggerFacade = new MultiLogger();
            ((MultiLogger)_loggerFacade).AddLogger(new DebugConsoleLogger());

            return _loggerFacade;
        }
    }
}
