using System;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class Influence : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public Guid InfluencedObjectId { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public TrackableDateStamp TimeOfInfluence { get; set; }
    }
}
