using System.Collections.ObjectModel;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.DiceGeneration.DiceRollerNuget
{
#pragma warning disable CS8644 // Type does not implement interface member. Nullability of reference types in interface implemented by the base type doesn't match.
    internal class DiceRollerDiceCollection : Collection<IDice>, IDiceCollection
#pragma warning restore CS8644 // Type does not implement interface member. Nullability of reference types in interface implemented by the base type doesn't match.
    {
        public int LastRollResultSum { get; private set; }

        public int RollAll()
        {
            LastRollResultSum = 0;

            foreach (IDice dice in this)
            {
                dice.Roll();
                LastRollResultSum += dice.LastRollResult;
            }

            return LastRollResultSum;
        }
    }
}
