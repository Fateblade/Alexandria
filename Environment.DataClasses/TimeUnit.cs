using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class TimeUnit
    {
        public string Name { get; set; }
        /// <summary>
        /// Default is one relation to that target, multiple values determine alternating flow ie, month 31,28,31,30,.....
        /// </summary>
        public List<TimeRelation> RelationValues { get; } = new List<TimeRelation>();
        public TimeUnit RelationTarget { get; set; }
    }

    public class TimeRelation
    {
        public ulong Value { get; set; }
        public string Name { get; set; }
    }
}
