using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Models.Base;
using Fateblade.Alexandria.UI.WPF.Models.Entities;
using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class AdventureModel : ModifiableDataClassModel<Adventure>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string AdditionalReward { get; set; }
        public List<RewardModel> Rewards { get; set; } = new List<RewardModel>();
        public List<PlayerCharacterModel> ParticipatingCharacters { get; set; } = new List<PlayerCharacterModel>();
        public List<StageModel> Stages { get; set; } = new List<StageModel>();



        public AdventureModel(Adventure original) : base(original) { }
    }
}
