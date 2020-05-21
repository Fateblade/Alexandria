using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public class Session : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public string Summary { get; set; }
        public string Title { get; set; }
        public DateTime PlayDate { get; set; }
        public List<Guid> ParticipatingCharacterIds { get; set; } = new List<Guid>();
        public List<Guid> PlayedAdventureIds { get; set; } = new List<Guid>();
        public List<Guid> PlayedStageIds { get; set; } = new List<Guid>();
        public List<Guid> PlayedEncounterIds { get; set; } = new List<Guid>();
    }
}
