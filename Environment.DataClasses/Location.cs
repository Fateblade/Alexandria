using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class Location
    {
        public List<Guid> ConnectionIds { get; set; } = new List<Guid>();
        public string Summary { get; set; }
        public string Features { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid SubLocationOf { get; set; }
    }
}
