using System;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public class TextInfo
    {
        public Guid AssociatedObject { get; set; }
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }
    }
}
