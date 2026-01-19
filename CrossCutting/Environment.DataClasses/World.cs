using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class World : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public string Name;
        public string Summary;
        public string Timeline;
        public Guid TrackerId;
        public List<Guid> PlaneIds { get; set; } = new List<Guid>();
        public List<Guid> PantheonIds { get; set; } = new List<Guid>();
        public List<Guid> NpcIds { get; set; } = new List<Guid>();
        public List<Guid> MonsterIds { get; set; } = new List<Guid>();
        public List<Guid> FactionIds { get; set; } = new List<Guid>();
        public List<Guid> GroupIds { get; set; } = new List<Guid>();
        public List<Guid> CharacterIds { get; set; } = new List<Guid>();
        public List<Guid> NonPantheonDeityIds { get; set; } = new List<Guid>();
    }
}