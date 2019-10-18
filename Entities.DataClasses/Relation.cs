using System;

namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public class Relation
    {
        public Guid ID { get; set; }
        public Guid Source { get; set; }
        public Guid Target { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
    }
}
