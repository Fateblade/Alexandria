using System.Collections.ObjectModel;

namespace Alexandrian.Base.Models
{
    public class TimeDefinition : BaseObject
    {
        public static ObservableCollection<TimeUnit> Units { get; } = new ObservableCollection<TimeUnit>();
        
        
        // define wich units are to be displayed in a Datestring, maybe multiple Definitions? Base and Formats?
    }
}
