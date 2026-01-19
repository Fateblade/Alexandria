using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public class Player : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> NoGoTextInfoIds { get; set; } = new List<Guid>();
        public string GenderPronoun { get; set; }
        public List<Guid> LikeTextInfoIds { get; set; } = new List<Guid>();
        public List<Guid> DislikeTextInfoIds { get; set; } = new List<Guid>();
    }
}
