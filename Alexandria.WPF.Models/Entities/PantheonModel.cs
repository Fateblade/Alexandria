using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Models.Base;
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

        public PantheonModel(Pantheon original) : base(original)
        {
        }
    }
}
