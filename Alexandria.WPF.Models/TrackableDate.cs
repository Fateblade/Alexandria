namespace Alexandria.WPF.Models
{
    public struct TrackableDate
    {
        public ulong DatePartBase { get; private set; }
        public ulong DatePartExtension { get; private set; }

        public TrackableDate(ulong basePart, ulong extensionPart)
        {
            DatePartBase = basePart;
            DatePartExtension = extensionPart;
        }
        public TrackableDate(ulong basePart) 
            : this(basePart, 0) { }
    }
}
