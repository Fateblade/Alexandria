using System.Runtime.CompilerServices;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract;

[assembly: InternalsVisibleTo("Alexandria.Logic.Foundation.Meta.DiceGeneration.Tests")]

namespace Fateblade.Alexandria.Logic.Foundation.Meta.DiceGeneration.DiceRollerNuget
{
    public class DiceRollerComponentActivator : IComponentActivator
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
            kernel.RegisterUnique<IDiceOptionsManager, DiceOptionsManager>(new DiceOptionsManager());
            kernel.Register<IDiceFactory, DiceRollerDiceFactory>();
            kernel.Register<IComplexDiceFormulaBuilder, DiceRollerComplexDiceFormulaBuilder>();
        }

        public void AddMessageSubscriptions(IEventBroker broker)
        {
        }

        public void Configure(IConfigurator config)
        {
        }
    }
}
