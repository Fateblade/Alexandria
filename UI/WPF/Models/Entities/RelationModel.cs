using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class RelationModel : ModifiableDataClassModel<Relation>
    {
        public IIdentifiableGuidEntity SourceId { get; set; }
        public IIdentifiableGuidEntity TargetId { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        public RelationModel(Relation original) : base(original)
        {
        }
    }
}
