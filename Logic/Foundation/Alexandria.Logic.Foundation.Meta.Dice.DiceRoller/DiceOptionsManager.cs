using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract.DataClasses;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.DiceGeneration.DiceRollerNuget
{
    internal class DiceOptionsManager : IDiceOptionsManager
    {
        public RoundingOptions DiceFormulaRounding { get; set; } = RoundingOptions.AlwaysRoundDown;

        public DiceOptionsManager()
        {
            global::Dice.Roller.DefaultConfig.NormalSidesOnly = false;
        }
    }
}
