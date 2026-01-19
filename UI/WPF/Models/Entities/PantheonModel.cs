using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using System.Collections.ObjectModel;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class PantheonModel : ModifiableDataClassModel<Pantheon>
    {
        public string Name { get; set; }
        public string Concept { get; set; }
        public string Backstory { get; set; }
        public string Description { get; set; }
        public ObservableCollection<Deity> Deities;
        public int RelationCategoryId => (int)RelationCategory.Pantheon;

        public override Pantheon ModifiedEntity => throw new System.NotImplementedException();

        public PantheonModel(Pantheon original) : base(original)
        {
        }

        public override void ModifyOriginalEntity()
        {
            throw new System.NotImplementedException();
        }
    }
}
