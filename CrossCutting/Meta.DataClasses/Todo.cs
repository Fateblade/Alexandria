using System;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public class Todo : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public Guid AssociatedObjectId { get; set; }
        public string AssociatedObjectType { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
    }
}
