using System.Collections.Generic;

namespace Alexandria.WPF.Models
{
    public class TimeFormat
    {
        public string Name { get; set; }
        public IEnumerable<TimeUnit> UnitsToDisplay { get; set; }
    }
}
