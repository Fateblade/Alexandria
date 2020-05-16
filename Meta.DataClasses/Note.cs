using System;

namespace Fateblade.Alexandria.CrossCutting.Meta.DataClasses
{
    public class Note
    {
        public Guid Id { get; set; }
        public Guid AssociatedObject { get; set; }
        public string Description { get; set; }
    }
}
