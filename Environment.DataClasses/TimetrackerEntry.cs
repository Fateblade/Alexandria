using System;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class TimetrackerEntry
    {
        public TrackableDateStamp Date { get; set; }
        public string Summary { get; set; }
        public Guid AssociatedID { get; set; }
        public string Description { get; set; }
    }
}
