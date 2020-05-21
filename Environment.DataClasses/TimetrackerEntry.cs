using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class TimetrackerEntry : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public Guid AssociatedObjectId { get; set; }
        public TrackableDateStamp Date { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
    }
}
