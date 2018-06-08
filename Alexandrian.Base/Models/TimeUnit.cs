namespace Alexandrian.Base.Models
{
    public class TimeUnit
    {
        public string Name { get; set; }
        /// <summary>
        /// Default is one relation to that target, multiple values determine alternating flow ie, month 31,28,31,30,.....
        /// </summary>
        public ulong[] RelationValues { get; set; } = new ulong[1];
        public TimeUnit RelationTarget { get; set; }
        public bool IncludeInDefaultDescription { get; set; } = true;
    }
}
