using System.Collections.Generic;

namespace Alexandrian.Base.Models
{
    public class TimeFormat
    {
        public string Name { get; set; }
        public IEnumerable<TimeUnit> UnitsToDisplay { get; set; }
    }
}
