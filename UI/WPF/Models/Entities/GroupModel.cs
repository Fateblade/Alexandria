using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class GroupModel : ModifiableDataClassModel<Group>
    {
        public string Name { get; set; }
        public string Concept { get; set; }
        public string Backstory { get; set; }
        public string Description { get; set; }
        public int RelationCategoryId => (int)RelationCategory.Group;

        public GroupModel(Group original) : base(original)
        {
        }
    }
}
