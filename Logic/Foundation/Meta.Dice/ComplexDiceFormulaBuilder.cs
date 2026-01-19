using System.Collections.Generic;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice
{
    internal class ComplexDiceFormulaBuilder : IComplexDiceFormulaBuilder
    {
        private readonly IDiceFactory _diceFactory;
        private readonly IDiceOptionsManager _optionsManager;
        private readonly List<FormulaStep> _diceSteps;

        public ComplexDiceFormulaBuilder(IDiceFactory diceFactory, IDiceOptionsManager optionsManager)
            : this(diceFactory, optionsManager, new List<FormulaStep>())
        { }

        private ComplexDiceFormulaBuilder(IDiceFactory diceFactory, IDiceOptionsManager optionsManager, List<FormulaStep> existingSteps)
        {
            _diceFactory = diceFactory;
            _optionsManager = optionsManager;
            _diceSteps = existingSteps;
        }

        public IComplexDiceFormulaBuilder AddDice(DiceType type)
        {
            return AddDice(type, 1);
        }

        public IComplexDiceFormulaBuilder AddDice(DiceType type, int amount)
        {
            _diceSteps.Add(new DiceFormulaStep(type, amount));

            return this;
        }

        public IComplexDiceFormulaBuilder AddDiceWithFlatModifier(DiceType type, int amount, int modifier)
        {
            _diceSteps.Add(new DiceFormulaStep(type, amount, modifier));

            return this;
        }

        public IComplexDiceFormulaBuilder AddDiceWithMultiplier(DiceType type, int amount, int multiplicator)
        {
            _diceSteps.Add(new DiceFormulaStep(type, amount, multiplicator: multiplicator));

            return this;
        }

        public IComplexDiceFormulaBuilder AddDiceWithFlatModifierAndMultiplier(DiceType type, int amount, int modifier,
            int multiplicator)
        {
            _diceSteps.Add(new DiceFormulaStep(type, amount, modifier, multiplicator));

            return this;
        }

        public IComplexDiceFormulaBuilder AddDivider(int divider)
        {
            _diceSteps.Add(new DivisionStep(divider));

            return this;
        }

        public IComplexDiceFormulaBuilder AddFlatModifier(int modifier)
        {
            _diceSteps.Add(new DiceFormulaStep(modifier:modifier));

            return this;
        }

        public IComplexDiceFormulaBuilder AddMultiplicatorStep()
        {
            _diceSteps.Add(new MultiplierStep());

            return this;
        }

        public IComplexDiceFormulaBuilder AddMultiplicator(int multiplicator)
        {
            _diceSteps.Add(new MultiplicationStep(multiplicator));

            return this;
        }

        public IDiceFormula Build()
        {
            return new ComplexDiceFormula(_diceFactory, _optionsManager, _diceSteps.AsReadOnly());
        }

        public IComplexDiceFormulaBuilder Clone()
        {
            return new ComplexDiceFormulaBuilder(_diceFactory,_optionsManager, new List<FormulaStep>(_diceSteps.AsReadOnly()));
        }

        public void Clear()
        {
            _diceSteps.Clear();
        }
    }
}