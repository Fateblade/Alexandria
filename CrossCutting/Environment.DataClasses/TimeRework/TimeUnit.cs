using System;
using System.Collections.Generic;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses.TimeRework
{
    public class TimeUnit : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Default is one relation to that target, multiple values determine alternating flow ie, for month: January-31,February-28,March-31,.....
        /// </summary>
        public List<TimeRelation> RelationValues { get; } = new List<TimeRelation>();
        public TimeUnit RelationTarget { get; set; }
    }

    public struct TimeRelation
    {
        public ulong Value { get; set; }
        public string Name { get; set; }
    }
}
