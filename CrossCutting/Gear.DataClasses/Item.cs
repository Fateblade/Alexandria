using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System;

namespace Fateblade.Alexandria.CrossCutting.Gear.DataClasses
{
    public class Item : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public Guid OwningEntity { get; set; }
        public string OwningEntityType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Statistics { get; set; }
        public int RelationCategoryId { get; } = 4; //DirectReference#0001
    }
}
