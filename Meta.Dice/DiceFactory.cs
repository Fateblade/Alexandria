using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract;
using Troschuetz.Random;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice
{
    public class DiceFactory :IDiceFactory
    {
        private TRandom _currentGenerator;
        private DateTime _generatorInstancedAt;

        public DiceFactory()
        {
            _currentGenerator = new TRandom(new TRandom().NextUInt(uint.MaxValue));
            _generatorInstancedAt = DateTime.UtcNow;
        }

        public IDice CreateDice(DiceType diceType)
        {
            handleGeneratorRecreation();
            return new Dice(_currentGenerator, diceType);
        }

        public IDice CreateCustomDice(uint sides)
        {
            handleGeneratorRecreation();
            return new CustomDice(_currentGenerator, sides);
        }

        public IDiceCollection CreateDices(int amount, DiceType diceType)
        {
            if (amount < 0)  { throw new ArgumentException($"negative Amount not allowed", nameof(amount));}

            handleGeneratorRecreation();
            DiceCollection dicePool = new DiceCollection();

            for (int i = 0; i < amount; i++)
            {
                dicePool.Add(new Dice(_currentGenerator, diceType));
            }

            return dicePool;
        }

        public IDiceCollection CreateCustomDices(int amount, uint sides)
        {
            if (amount < 0) { throw new ArgumentException($"negative Amount not allowed", nameof(amount)); }

            handleGeneratorRecreation();
            DiceCollection dicePool = new DiceCollection();

            for (int i = 0; i < amount; i++)
            {
                dicePool.Add(new CustomDice(_currentGenerator, sides));
            }

            return dicePool;
        }

        public IDiceFormula CreateDiceFormula(DiceType diceType, int diceAmount, int modifier, bool isModifierPerDice, bool isNegativeModifierResultPerDiceAllowed)
        {
            return new DiceFormula(this, diceType, diceAmount, modifier, isModifierPerDice, isNegativeModifierResultPerDiceAllowed);
        }

        public IDiceFormula CreateDiceFormula(uint diceSides, int diceAmount, int modifier, bool isModifierPerDice, bool isNegativeModifierResultPerDiceAllowed)
        {
            return new DiceFormula(this, diceSides, diceAmount, modifier, isModifierPerDice, isNegativeModifierResultPerDiceAllowed);
        }

        public IDiceFormula CreateDiceFormula(IDiceCollection diceCollection, int modifier, bool isModifierPerDice, bool isNegativeModifierResultPerDiceAllowed)
        {
            return new DiceFormula(this, diceCollection, modifier, isModifierPerDice, isNegativeModifierResultPerDiceAllowed);
        }

        private void handleGeneratorRecreation()
        {
            if ((DateTime.Now - _generatorInstancedAt).Minutes > 30)
            {
                _currentGenerator = new TRandom(_currentGenerator.NextUInt(uint.MaxValue));
                _generatorInstancedAt = DateTime.Now;
            }
        }
    }
}
