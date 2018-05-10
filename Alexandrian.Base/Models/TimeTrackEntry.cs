using System;

namespace Alexandrian.Base.Models
{
    public class TimetrackEntry
    {
        public TrackableDate Date { get; set; }
        public string Summary { get; set; }
        public Guid AssociatedID { get; set; }
    }
}
