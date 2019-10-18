using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public abstract class Entity
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Statistics { get; set; }

        //properties - cross reference meta
        public int SystemID { get; set; }

        //properties - cross reference items
        public List<int> ItemIDs { get; set; }
        //properties - cross links
        public abstract int RelationCategoryID { get; }

    }
}
