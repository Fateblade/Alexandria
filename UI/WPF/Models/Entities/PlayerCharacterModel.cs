using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using Fateblade.Alexandria.UI.WPF.Models.Meta;
using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class PlayerCharacterModel : ModifiableDataClassModel<PlayerCharacter>
    {
        public PlayerModel ControllingPlayer { get; set; }

        public string PowerLevel { get; set; }
        public string Classification { get; set; }
        public string Backstory { get; set; }
        public string Origin { get; set; } //maybe bind to location?

        public List<Flaw> Flaws { get; set; }
        public List<StrongSuit> StrongSuits { get; set; }
        public List<Ambition> Ambitions { get; set; }
        public List<Fear> Fears { get; set; }
        public List<Goal> Goals { get; set; }
        public string Moral { get; set; }

        public int RelationCategoryId => (int)RelationCategory.PC;

        public override PlayerCharacter ModifiedEntity => throw new System.NotImplementedException();

        public PlayerCharacterModel(PlayerCharacter original) : base(original)
        {
        }

        public override void ModifyOriginalEntity()
        {
            throw new System.NotImplementedException();
        }
    }
}