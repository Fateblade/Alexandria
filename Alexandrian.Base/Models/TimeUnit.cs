namespace Alexandrian.Base.Models
{
    public class TimeUnit
    {
        public string Name { get; set; }
        public ulong RelationValue { get; set; }
        public TimeUnit RelationTarget { get; set; }
    }
}
