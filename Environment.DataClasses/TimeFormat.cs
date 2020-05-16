using System;
using System.Collections.Generic;
using System.Text;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class TimeFormat
    {
        public string Name { get; set; }
        public IEnumerable<TimeUnit> UnitsToDisplay { get; set; }
    }
}
