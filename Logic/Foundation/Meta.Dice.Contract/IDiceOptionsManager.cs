using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract.DataClasses;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract
{
    public interface IDiceOptionsManager
    {
        RoundingOptions DiceFormulaRounding { get; set; }
    }
}
