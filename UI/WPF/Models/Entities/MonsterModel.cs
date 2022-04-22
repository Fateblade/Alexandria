using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using Fateblade.Alexandria.UI.WPF.Models.Gear;
using System;
using System.Collections.Generic;

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

        public override Monster ModifiedEntity => throw new NotImplementedException();

        public MonsterModel(Monster original) : base(original)
        {
        }

        public override void ModifyOriginalEntity()
        {
            throw new NotImplementedException();
        }
    }
}
