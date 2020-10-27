using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public class Note : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public Guid AssociatedObject { get; set; }
        public string AssociatedObjectType { get; set; }
        public string Description { get; set; }
    }
}
