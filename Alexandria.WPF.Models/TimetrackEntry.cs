using System;

namespace Alexandria.WPF.Models
{
    public class TimetrackEntry
    {
        public TrackableDate Date { get; set; }
        public string Summary { get; set; }
        public Guid AssociatedID { get; set; }
        public string Description { get; set; }
    }
}
