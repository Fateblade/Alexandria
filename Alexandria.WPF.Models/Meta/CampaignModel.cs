using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Models.Base;
using Fateblade.Alexandria.UI.WPF.Models.Entities;
using Fateblade.Alexandria.UI.WPF.Models.Environment;
using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class CampaignModel : ModifiableDataClassModel<Campaign>
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Theme { get; set; }
        public WorldModel WorldIdPlayedIn { get; set; }
        public List<SessionModel> Sessions { get; set; } = new List<SessionModel>();
        public List<AdventureModel> Adventures { get; set; } = new List<AdventureModel>();
        public List<PlayerCharacterModel> PlayingCharacters { get; set; } = new List<PlayerCharacterModel>();

        public CampaignModel(Campaign original) : base(original)
        {
        }
    }
}
