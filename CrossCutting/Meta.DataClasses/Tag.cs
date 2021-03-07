using System;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public class Tag : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public Guid AssociatedObject { get; set; }
        public string AssociatedObjectType { get; set; }
        public string Name { get; set; }
        public string ColorCode { get; set; }
    }
}
