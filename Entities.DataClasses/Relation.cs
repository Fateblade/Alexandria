using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;

namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public class Relation : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public Guid SourceId { get; set; }
        public Guid TargetId { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
    }
}
