using System;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract.DataClasses;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.DiceGeneration.DiceRollerNuget
{
    internal class SimpleDiceRollerDiceFormula : IDiceFormula
    {
        private readonly IDiceOptionsManager _optionsManager;
        private readonly string _diceFormula;

        public SimpleDiceRollerDiceFormula(IDiceOptionsManager optionsManager, string diceFormula)
        {
            _optionsManager = optionsManager;
            _diceFormula = diceFormula;
        }

        public int Roll()
        {
            return roundAccordingToOptions(global::Dice.Roller.Roll(_diceFormula).Value);
        }

        private int roundAccordingToOptions(decimal diceResult)
        {
            bool diceResultHasFractionalPart = diceResult % 1.0m != 0.0m;

            if (diceResultHasFractionalPart && _optionsManager.DiceFormulaRounding == RoundingOptions.AlwaysRoundDown)
            {
                return Convert.ToInt32(diceResult)+1;
            }
            else if (diceResultHasFractionalPart && _optionsManager.DiceFormulaRounding == RoundingOptions.AlwaysRoundUp)
            {
                return Convert.ToInt32(diceResult);
            }
            else
            {
                return Convert.ToInt32(Math.Round(diceResult, 0));
            }

        }
    }
}
