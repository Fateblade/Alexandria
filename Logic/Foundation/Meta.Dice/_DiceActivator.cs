using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Alexandria.Logic.Foundation.Meta.DiceGeneration.Tests")]


namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice
{
    public class DiceActivator : IComponentActivator
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
            kernel.Register<IDiceFactory, DiceFactory>();
            kernel.Register<IComplexDiceFormulaBuilder, ComplexDiceFormulaBuilder>();
        }

        public void AddMessageSubscriptions(IEventBroker broker)
        {
        }

        public void Configure(IConfigurator config)
        {
        }
    }
}
