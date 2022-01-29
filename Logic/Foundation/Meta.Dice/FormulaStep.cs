using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice
{
    internal abstract class FormulaStep {}

    internal class DiceFormulaStep : FormulaStep
    {
        public DiceType? DiceType { get; set; }
        public int? Amount { get; set; }
        public int? Modifier { get; set; }
        public int? Multiplicator { get; set; }

        public DiceFormulaStep(DiceType? diceType = null, int? amount = null, int? modifier = null, int? multiplicator = null)
        {
            DiceType = diceType;
            Amount = amount;
            Multiplicator = multiplicator;
            Modifier = modifier;
        }
    }

    internal class MultiplicationStep : FormulaStep
    {
        public int Multiplicator { get; set; }

        public MultiplicationStep(int multiplicator)
        {
            Multiplicator = multiplicator;
        }
    }

    internal class DivisionStep : FormulaStep
    {
        public int Divider { get; set; }

        public DivisionStep(int divider)
        {
            Divider = divider;
        }
    }

    internal class MultiplierStep : FormulaStep
    {
    }

}