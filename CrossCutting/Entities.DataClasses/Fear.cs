using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;

namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public class Fear : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }
    }
}