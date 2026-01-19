using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using Troschuetz.Random;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice
{
    class CustomDice : IDice
    {
        private readonly TRandom _generatorInstance;

        public DiceType DiceType { get; }
        public int LastRollResult { get; private set; }
        public uint Sides { get; }

        internal CustomDice(TRandom generatorInstanceToUse, uint diceSides)
        {
            if (diceSides < 1)
            {
                throw new ArgumentException("Dice sides may not be lower than 1", nameof(diceSides));
            }

            Sides = diceSides;
            DiceType = DiceType.Custom;
            _generatorInstance = generatorInstanceToUse;
        }

        public int Roll()
        {
            LastRollResult = (int) _generatorInstance.Generator.NextUInt(1, Sides);
            return LastRollResult;
        }
    }
}