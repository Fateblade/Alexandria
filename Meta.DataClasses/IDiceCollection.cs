using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public interface IDiceCollection : ICollection<IDice>
    {
        int RollAll();
        int LastRollResultSum { get; }
    }
}
