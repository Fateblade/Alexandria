using System;
using System.Collections.Generic;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class Influence : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public Guid InfluencedObjectId { get; set; }
        public string InfluencedObjectType { get; set; }
        public List<Influencer> InfluencingObjectIds { get; set; } = new List<Influencer>();
        public string Summary { get; set; }
        public string Description { get; set; }
        public TrackableDateStamp TimeOfInfluence { get; set; }
    }
}
