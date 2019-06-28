using System.Collections.Generic;

namespace Alexandrian.Base.Interfaces
{
    public interface IAttachable<T>
    {
        List<T> Attached { get; }
        void Add(T element);
        void Remove(T element);
        IEnumerable<T> GetList();
    }
}
