using System;
using System.Collections.Generic;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses.TimeRework
{
    public class TimeFormat : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> UnitIdsToDisplay { get; set; } = new List<Guid>();
    }
}
