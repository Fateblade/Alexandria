using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class StageModel : ModifiableDataClassModel<Stage>
    {
        public string Summary { get; set; }
        public string Description { get; set; }
        public string AdditionalReward { get; set; }
        public List<TextInfo> RewardSummary { get; set; } = new List<TextInfo>();
        public List<EncounterModel> Encounters { get; set; } = new List<EncounterModel>();

        public StageModel(Stage original) : base(original)
        {
        }
    }

}