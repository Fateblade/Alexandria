using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System.Collections.ObjectModel;

namespace Fateblade.Alexandria.Logic.Foundation.Meta.Dice
{
    class DiceCollection : Collection<IDice>, IDiceCollection
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
