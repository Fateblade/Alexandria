using System;
using System.Collections.Generic;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public abstract class Entity : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Statistics { get; set; }

        //properties - cross reference meta
        public Guid SystemId { get; set; }

        //properties - cross reference items
        public List<Guid> ItemIds { get; set; }
        //properties - cross links
        public abstract int RelationCategoryId { get; }

    }
}
