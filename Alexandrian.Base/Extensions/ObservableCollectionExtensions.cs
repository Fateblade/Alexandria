using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Alexandrian.Base.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> oc, IEnumerable<T> elements)
        {
            foreach(T element in elements)
            {
                oc.Add(element);
            }
        }
    }
}
