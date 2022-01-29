using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using Fateblade.Alexandria.Logic.Foundation.Meta.Dice.Contract;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice
{
    class SimpleDiceFormula : IDiceFormula
    {
        private readonly IDiceFactory _diceFactory;
        private readonly int _modifier;
        private readonly bool _isModifierPerDice;
        private readonly bool _isNegativeModifierResultPerDiceAllowed;
        private readonly IDiceCollection _diceCollection;

        internal SimpleDiceFormula(IDiceFactory diceFactory, DiceType diceType, int diceAmount, int modifier, bool isModifierPerDice, bool isNegativeModifierResultPerDiceAllowed)
            : this(diceFactory, modifier, isModifierPerDice, isNegativeModifierResultPerDiceAllowed)
        {
            _diceCollection = new DiceCollection();
            for (int i = 0; i < diceAmount; i++)
            {
                _diceCollection.Add(_diceFactory.CreateDice(diceType));
            }
        }

        internal SimpleDiceFormula(IDiceFactory diceFactory, uint diceSides, int diceAmount, int modifier, bool isModifierPerDice, bool isNegativeModifierResultPerDiceAllowed)
            : this(diceFactory, modifier, isModifierPerDice, isNegativeModifierResultPerDiceAllowed)
        {
            _diceCollection = new DiceCollection();
            for (int i = 0; i < diceAmount; i++)
            {
                _diceCollection.Add(_diceFactory.CreateCustomDice(diceSides));
            }
        }

        internal SimpleDiceFormula(IDiceFactory diceFactory, IDiceCollection diceCollection, int modifier, bool isModifierPerDice, bool isNegativeModifierResultPerDiceAllowed)
            : this(diceFactory, modifier, isModifierPerDice, isNegativeModifierResultPerDiceAllowed)
        {
            _diceCollection = diceCollection;
        }

        private SimpleDiceFormula(IDiceFactory diceFactory, int modifier, bool isModifierPerDice, bool isNegativeModifierResultPerDiceAllowed)
        {
            _diceFactory = diceFactory;
            _modifier = modifier;
            _isModifierPerDice = isModifierPerDice;
            _isNegativeModifierResultPerDiceAllowed = isNegativeModifierResultPerDiceAllowed;
        }

        public int Roll()
        {
            int result = 0;
            _diceCollection.RollAll();
            if (_isNegativeModifierResultPerDiceAllowed)
            {
                int totalModifier = _isModifierPerDice ? _modifier * _diceCollection.Count : _modifier;
                result = _diceCollection.LastRollResultSum + totalModifier;
            }
            else if (_isModifierPerDice)
            {
                foreach (IDice dice in _diceCollection)
                {
                    result += Math.Max(dice.LastRollResult + _modifier, 0);
                }
            }
            else
            {
                result += Math.Max(_diceCollection.LastRollResultSum + _modifier, 0);
            }

            return result;
        }
    }
}
