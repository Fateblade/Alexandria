using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.Logic.Foundation.TextMathParser.Contract;

namespace Fateblade.Alexandria.Logic.Foundation.TextMathParser.mXparser
{
    // ReSharper disable once InconsistentNaming
    public class TextMathParserMXParserActivator : IComponentActivator
    {
        public void Activating()
        {
        }

        public void Activated()
        {
        }

        public void Deactivating()
        {
        }

        public void Deactivated()
        {
        }

        public void RegisterMappings(ICoCoKernel kernel)
        {
            kernel.Register<ITextMathParser, TextMathParser>();
        }

        public void AddMessageSubscriptions(IEventBroker broker)
        {
        }

        public void Configure(IConfigurator config)
        {
        }
    }
}
