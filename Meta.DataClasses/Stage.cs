using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public class Stage : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string AdditionalReward { get; set; }
        public List<string> RewardSummary { get; set; } = new List<string>();
        public List<Guid> EncounterIds { get; set; } = new List<Guid>();
    }

}
