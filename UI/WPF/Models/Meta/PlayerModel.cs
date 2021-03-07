using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class PlayerModel : ModifiableDataClassModel<Player>
    {
        public string Name { get; set; }
        public List<TextInfoModel> NoGos { get; set; } = new List<TextInfoModel>();
        public string GenderPronoun { get; set; }
        public List<TextInfoModel> Likes { get; set; } = new List<TextInfoModel>();
        public List<TextInfoModel> Dislikes { get; set; } = new List<TextInfoModel>();

        public PlayerModel(Player original) : base(original)
        {
        }
    }
}
