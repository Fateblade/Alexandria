using System;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public class TextInfo : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public Guid AssociatedObject { get; set; }
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }
    }
}
