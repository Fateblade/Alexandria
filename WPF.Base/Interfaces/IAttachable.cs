using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Base.Interfaces
{
    public interface IAttachable<T>
    {
        List<T> Attached { get; }
        void Add(T element);
        void Delete(T element);
        IEnumerable<T> GetList();
    }
}
