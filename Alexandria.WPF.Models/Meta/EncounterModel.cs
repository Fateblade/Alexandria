using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Models.Base;
using Fateblade.Alexandria.UI.WPF.Models.Entities;
using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class EncounterModel : ModifiableDataClassModel<Encounter>
    {
        public EncounterType Type { get; set; }
        public List<MonsterModel> ParticipatingMonsters { get; set; } = new List<MonsterModel>();
        public List<NonPlayerCharacterModel> ParticipatingNpcs { get; set; } = new List<NonPlayerCharacterModel>();
        public string Description { get; set; }
        public string Summary { get; set; }
        public List<RewardModel> Rewards { get; set; } = new List<RewardModel>();
        public string ConsequenceSuccess { get; set; }
        public string ConsequenceFailure { get; set; }
        public EncounterState State { get; set; }

        public EncounterModel(Encounter original) : base(original)
        {
        }
    }
}
