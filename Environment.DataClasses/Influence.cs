using System;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class Influence
    {
        public Guid InfluencedObject { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public TrackableDateStamp TimeOfInfluence { get; set; }
    }
}
