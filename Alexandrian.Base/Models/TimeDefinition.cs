using System.Collections.ObjectModel;

namespace Alexandrian.Base.Models
{
    public class TimeDefinition : BaseObject
    {
        public ObservableCollection<TimeUnit> Units { get; } = new ObservableCollection<TimeUnit>();
        public ObservableCollection<TimeFormat> Formats { get; } = new ObservableCollection<TimeFormat>();
        public TimeFormat DefaultFormat { get; set; }
        // define wich units are to be displayed in a Datestring, maybe multiple Definitions? Base and Formats?
    }
}
