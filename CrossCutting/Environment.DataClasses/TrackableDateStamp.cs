namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public struct TrackableDateStamp
    {
        public ulong DatePartBase { get; private set; }
        public ulong DatePartExtension { get; private set; }

        public TrackableDateStamp(ulong basePart, ulong extensionPart)
        {
            DatePartBase = basePart;
            DatePartExtension = extensionPart;
        }
        public TrackableDateStamp(ulong basePart)
            : this(basePart, 0) { }
    }
}
