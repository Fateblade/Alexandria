using System.Collections.ObjectModel;

namespace Alexandrian.Base.Models
{
    public class TimeDefinition : BaseObject
    {
        public static ObservableCollection<TimeUnit> Units { get; } = new ObservableCollection<TimeUnit>();
    }
}
