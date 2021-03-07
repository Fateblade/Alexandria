using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class FactionModel : ModifiableDataClassModel<Faction>
    {
        public string Motto;
        public string Goals;
        public string Beliefs;
        public int RelationCategoryId => (int)RelationCategory.Faction;
        public string Name { get; set; }
        public string Concept { get; set; }
        public string Backstory { get; set; }
        public string Description { get; set; }

        public FactionModel(Faction original) : base(original)
        {
        }
    }
}
