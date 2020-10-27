using Fateblade.Alexandria.CrossCutting.Gear.DataClasses;
using Fateblade.Alexandria.UI.WPF.Models.Base;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.UI.WPF.Models.Gear
{
    public class ItemModel : ModifiableDataClassModel<Item>
    {
        public IIdentifiableGuidEntity OwningEntity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Statistics { get; set; }
        public int RelationCategoryID { get; }

        public ItemModel(Item original) : base(original)
        {
        }
    }
}
