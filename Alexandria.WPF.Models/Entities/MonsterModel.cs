using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Models.Base;
using System;
using System.Collections.Generic;
using Fateblade.Alexandria.UI.WPF.Models.Gear;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class MonsterModel : ModifiableDataClassModel<Monster>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Statistics { get; set; }
        public Guid SystemId { get; set; }
        public List<ItemModel> Items { get; set; }
        public string Type { get; set; }
        public int RelationCategoryId => (int)RelationCategory.Monster;

        public MonsterModel(Monster original) : base(original)
        {
        }
    }
}
