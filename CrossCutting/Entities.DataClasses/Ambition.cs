using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;

namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public class Ambition : IIdentifiableGuidEntity
    {
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }
        public Guid Id { get; set; }
    }
}