using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class Location : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public List<Guid> ConnectionIds { get; set; } = new List<Guid>();
        public string Summary { get; set; }
        public string Features { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid SubLocationOf { get; set; }
    }
}
