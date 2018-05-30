using System;

namespace Alexandrian.Base.Models
{
    public class Influence
    {
        public Guid InfluencedObject { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public TrackableDate TimeOfInfluence { get; set; }
    }
}
        