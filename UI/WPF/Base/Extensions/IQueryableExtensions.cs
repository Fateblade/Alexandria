using System.Collections.ObjectModel;
using System.Linq;

namespace Fateblade.Alexandria.UI.WPF.Base.Extensions
{
    public static class QueryableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IQueryable<T> queryable)
        {
            return new ObservableCollection<T>(queryable);
        }
    }
}
