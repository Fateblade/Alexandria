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
        public List<Guid> PlaneIds = new List<Guid>();
        public List<Guid> PantheonIds = new List<Guid>();
        public List<Guid> NpcIds = new List<Guid>();
        public List<Guid> MonsterIds = new List<Guid>();
        public List<Guid> FactionIds = new List<Guid>();
        public List<Guid> GroupIds = new List<Guid>();
    }
}
