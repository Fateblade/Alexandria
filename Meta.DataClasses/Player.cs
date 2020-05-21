using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public class Player : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> NoGoIds { get; set; } = new List<Guid>();
        public string GenderPronoun { get; set; }
        public List<Guid> LikeIds { get; set; } = new List<Guid>();
        public List<Guid> DislikeIds { get; set; } = new List<Guid>();
    }
}
