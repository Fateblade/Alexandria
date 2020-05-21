using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public class Campaign : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Theme { get; set; }
        public Guid WorldIdPlayedIn { get; set; }
        public List<Guid> SessionIds { get; set; } = new List<Guid>();
        public List<Guid> AdventureIds { get; set; } = new List<Guid>();
        public List<Guid> PlayingCharacterIds { get; set; } = new List<Guid>();
    }
}
