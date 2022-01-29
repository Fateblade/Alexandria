using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Troschuetz.Random;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice
{
    class Dice : IDice
    {
        private readonly TRandom _generatorInstance;

        public uint Sides { get; }
        public DiceType DiceType { get; }
        public int LastRollResult { get; private set; }

        internal Dice(TRandom generatorInstanceToUse, DiceType diceType)
        {
            DiceType = diceType;
            _generatorInstance = generatorInstanceToUse;
            Sides = (uint)DiceType;
        }


        public int Roll()
        {
            if (DiceType == DiceType.Custom)
            {
                LastRollResult = 0;
            }
            else
            {
                LastRollResult = (int)_generatorInstance.Generator.NextUInt(1, (uint)DiceType);
            }
            
            return LastRollResult;
        }
    }
}
