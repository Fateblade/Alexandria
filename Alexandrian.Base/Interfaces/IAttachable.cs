using System.Collections.Generic;

namespace Alexandrian.Base.Interfaces
{
    public interface IAttachable<T>
    {
        void Add(T element);
        void Remove(T element);
        IEnumerable<T> GetList();
    }
}
