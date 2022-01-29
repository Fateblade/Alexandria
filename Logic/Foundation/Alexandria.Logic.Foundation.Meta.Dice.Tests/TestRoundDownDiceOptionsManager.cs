using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract.DataClasses;

namespace Alexandria.Logic.Foundation.Meta.DiceGeneration.Tests;

internal class TestRoundDownDiceOptionsManager : IDiceOptionsManager
{
    public RoundingOptions DiceFormulaRounding { get; set; } = RoundingOptions.AlwaysRoundDown;
}