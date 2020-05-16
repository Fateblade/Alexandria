using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class Location
    {
        public List<Guid> Connections;
        public string Summary;
        public string Features;
        public string Name;
        public string Description;
        public Guid SubLocationOf;
    }
}
