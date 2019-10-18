using System;

namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public class Group
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Concept { get; set; }
        public string Backstory { get; set; }
        public string Description { get; set; }
        public virtual int RelationCategoryID => (int)RelationCategory.Group;
    }
}
