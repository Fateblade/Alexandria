using System.Text;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.DiceGeneration.DiceRollerNuget
{
    internal class DiceRollerComplexDiceFormulaBuilder : IComplexDiceFormulaBuilder
    {
        private enum ControlSign
        {
            Addition,
            Multiplication,
            Division,
            Substraction
        }

        private readonly IDiceOptionsManager _optionsManager;
        private readonly StringBuilder _diceFormulaStringBuilder;
        private ControlSign _nextControlSign;

        public DiceRollerComplexDiceFormulaBuilder(IDiceOptionsManager optionsManager, string existingString)
        {
            _optionsManager = optionsManager;
            _diceFormulaStringBuilder = new StringBuilder(existingString);
            _nextControlSign = ControlSign.Addition;
        }

        public DiceRollerComplexDiceFormulaBuilder(IDiceOptionsManager optionsManager)
            : this(optionsManager, string.Empty)
        {
        }

        public IComplexDiceFormulaBuilder AddDice(DiceType type)
        {
            return AddDice(type, 1);
        }

        public IComplexDiceFormulaBuilder AddDice(uint sides)
        {
            return AddDice(sides, 1);
        }

        public IComplexDiceFormulaBuilder AddDice(IDice diceToAdd)
        {
            return diceToAdd.DiceType != DiceType.Custom 
                ? AddDice(diceToAdd.DiceType) 
                : AddDice(diceToAdd.Sides);
        }

        public IComplexDiceFormulaBuilder AddDice(DiceType type, int amount)
        {
            append($"{amount}d{(int)type}");

            return this;
        }

        public IComplexDiceFormulaBuilder AddDice(uint sides, int amount)
        {
            append($"{amount}d{sides}");

            return this;
        }

        public IComplexDiceFormulaBuilder AddDiceWithFlatModifier(DiceType type, int amount, int modifier)
        {
            append($"{amount}d{(int)type}+{modifier}");

            return this;
        }

        public IComplexDiceFormulaBuilder AddDiceWithFlatModifier(uint sides, int amount, int modifier)
        {
            append($"{amount}d{sides}+{modifier}");

            return this;
        }

        public IComplexDiceFormulaBuilder AddDiceWithMultiplier(DiceType type, int amount, int multiplier)
        {
            append($"{amount}d{(int)type}*{multiplier}");

            return this;
        }

        public IComplexDiceFormulaBuilder AddDiceWithFlatModifierAndMultiplier(DiceType type, int amount, int modifier,
            int multiplicator)
        {
            append($"({amount}d{(int)type}+{modifier})*{multiplicator}");

            return this;
        }

        public IComplexDiceFormulaBuilder AddMultiplicator(int multiplicator)
        {
            _nextControlSign = ControlSign.Multiplication;
            append(multiplicator.ToString());

            return this;
        }

        public IComplexDiceFormulaBuilder AddDivider(int divider)
        {
            _nextControlSign = ControlSign.Division;
            append(divider.ToString());

            return this;
        }

        public IComplexDiceFormulaBuilder AddFlatModifier(int modifier)
        {
            append(modifier.ToString());

            return this;
        }

        public IComplexDiceFormulaBuilder AddMultiplicatorStep()
        {
            _nextControlSign = ControlSign.Multiplication;

            return this;
        }

        public IComplexDiceFormulaBuilder Clone()
        {
            return new DiceRollerComplexDiceFormulaBuilder(_optionsManager, _diceFormulaStringBuilder.ToString());
        }

        public void Clear()
        {
            _diceFormulaStringBuilder.Clear();
        }

        public IDiceFormula Build()
        {
            return new SimpleDiceRollerDiceFormula(_optionsManager, _diceFormulaStringBuilder.ToString());
        }

        private void append(string formulaPart)
        {
            _diceFormulaStringBuilder.Append(
                _nextControlSign == ControlSign.Addition ? "+" :
                _nextControlSign == ControlSign.Substraction ? "-" :
                _nextControlSign == ControlSign.Multiplication ? "*" :
                _nextControlSign == ControlSign.Division ? "/" :
                "");

            _diceFormulaStringBuilder.Append(formulaPart);

            //reset to standard addition for next append
            _nextControlSign = ControlSign.Addition;
        }
    }
}
