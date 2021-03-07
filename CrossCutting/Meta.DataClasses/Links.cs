using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public enum LinkType { Undefined, Website, Document }

    public class Link : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public Guid AssociatedObject { get; set; }
        public string AssociatedObjectType { get; set; }
        public LinkType Type { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}
