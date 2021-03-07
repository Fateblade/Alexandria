using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Models.Environment
{
    public class InfluenceModel : ModifiableDataClassModel<Influence>
    {
        public IIdentifiableGuidEntity InfluencedObjectId { get; set; }
        public List<IIdentifiableGuidEntity> InfluencingObjectIds { get; set; } = new List<IIdentifiableGuidEntity>();
        public string Summary { get; set; }
        public string Description { get; set; }
        public TrackableDateStamp TimeOfInfluence { get; set; }

        public InfluenceModel(Influence original) : base(original)
        {
        }
    }
}
