using System;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.DiceGeneration.DiceRollerNuget
{
    internal class DiceRollerDice : IDice
    {
        private int _lastResult;

        public DiceType DiceType { get; }
        public int LastRollResult => _lastResult;
        public uint Sides { get; }

        public DiceRollerDice(DiceType diceType)
        {
            DiceType = diceType;
            Sides = (uint)DiceType;
        }

        public DiceRollerDice(uint sides)
            : this(DiceType.Custom)
        {
            Sides = sides;
        }

        public int Roll()
        {
            var result = global::Dice.Roller.Roll($"1d{Sides}");
            _lastResult = Convert.ToInt32(result.Value);

            return _lastResult;
        }
    }
}
