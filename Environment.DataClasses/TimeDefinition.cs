using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class TimeDefinition
    {
        public List<TimeUnit> Units { get; } = new List<TimeUnit>();
        public List<TimeFormat> Formats { get; } = new List<TimeFormat>();
        public TimeFormat DefaultFormat { get; set; }
        // define wich units are to be displayed in a Datestring, maybe multiple Definitions? Base and Formats?
    }
}
