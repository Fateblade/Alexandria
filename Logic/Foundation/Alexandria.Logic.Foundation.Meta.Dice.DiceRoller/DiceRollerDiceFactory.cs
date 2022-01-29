using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.DiceGeneration.DiceRollerNuget
{
    internal class DiceRollerDiceFactory : IDiceFactory
    {
        private readonly IDiceOptionsManager _optionsManager;

        public DiceRollerDiceFactory(IDiceOptionsManager optionsManager)
        {
            _optionsManager = optionsManager;
        }

        public IDice CreateDice(DiceType diceType)
        {
            return new DiceRollerDice(diceType);
        }

        public IDice CreateCustomDice(uint sides)
        {
            return new DiceRollerDice(sides);
        }

        public IDiceCollection CreateDices(int amount, DiceType diceType)
        {
            var diceCollection = new DiceRollerDiceCollection();

            for (int i = 0; i < amount; i++)
            {
                diceCollection.Add(CreateDice(diceType));
            }

            return diceCollection;
        }

        public IDiceCollection CreateCustomDices(int amount, uint sides)
        {
            var diceCollection = new DiceRollerDiceCollection();

            for (int i = 0; i < amount; i++)
            {
                diceCollection.Add(CreateCustomDice(sides));
            }

            return diceCollection;
        }

        public IDiceFormula CreateDiceFormula(DiceType diceType, int diceAmount, int modifier, bool isModifierPerDice,
            bool isNegativeModifierResultPerDiceAllowed)
        {
            var builder = new DiceRollerComplexDiceFormulaBuilder(_optionsManager);

            if (isModifierPerDice)
            {
                if (modifier < 0 && !isNegativeModifierResultPerDiceAllowed)
                    throw new Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract.Exceptions.DiceException("Negative dice modifier per dice is not allowed");

                for (int i =0;i<diceAmount;i++)
                {
                    builder.AddDice(diceType);
                    builder.AddFlatModifier(modifier);
                }
            }
            else
            {
                builder.AddDiceWithFlatModifier(diceType, diceAmount, modifier);
            }

            return builder.Build();
        }

        public IDiceFormula CreateDiceFormula(uint diceSides, int diceAmount, int modifier, bool isModifierPerDice,
            bool isNegativeModifierResultPerDiceAllowed)
        {
            var builder = new DiceRollerComplexDiceFormulaBuilder(_optionsManager);

            if (isModifierPerDice)
            {
                if (modifier < 0 && !isNegativeModifierResultPerDiceAllowed)
                    throw new Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract.Exceptions.DiceException("Negative dice modifier per dice is not allowed");

                for (int i = 0; i < diceAmount; i++)
                {
                    builder.AddDice(diceSides);
                    builder.AddFlatModifier(modifier);
                }
            }
            else
            {
                builder.AddDiceWithFlatModifier(diceSides, diceAmount, modifier);
            }

            return builder.Build();

        }

        public IDiceFormula CreateDiceFormula(IDiceCollection dices, int modifier, bool isModifierPerDice,
            bool isNegativeModifierResultPerDiceAllowed)
        {
            var builder = new DiceRollerComplexDiceFormulaBuilder(_optionsManager);

            if (isModifierPerDice)
            {
                if (modifier < 0 && !isNegativeModifierResultPerDiceAllowed)
                    throw new Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract.Exceptions.DiceException("Negative dice modifier per dice is not allowed");

                foreach (IDice dice in dices)
                {
                    builder.AddDice(dice);
                    builder.AddFlatModifier(modifier);
                }
            }
            else
            {
                foreach (var dice in dices)
                {
                    builder.AddDice(dice);
                }

                builder.AddFlatModifier(modifier);
            }

            return builder.Build();
        }

        public IDiceFormula FromString(string diceFormula)
        {
            return new SimpleDiceRollerDiceFormula(_optionsManager, diceFormula);
        }
    }
}
