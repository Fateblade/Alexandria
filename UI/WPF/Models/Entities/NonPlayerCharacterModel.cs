using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using Fateblade.Alexandria.UI.WPF.Models.Gear;
using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class NonPlayerCharacterModel : ModifiableDataClassModel<NonPlayerCharacter>
    {
        public string PowerLevel { get; set; }
        public string Classification { get; set; }
        public string Backstory { get; set; }
        public string Origin { get; set; }

        public List<Flaw> Flaws { get; set; }
        public List<StrongSuit> StrongSuits { get; set; }
        public List<Ambition> Ambitions { get; set; }
        public List<Fear> Fears { get; set; }
        public List<Goal> Goals { get; set; }
        public string Moral { get; set; }
        public int RelationCategoryId => (int)RelationCategory.NPC;

        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Statistics { get; set; }

        public Guid SystemId { get; set; }

        public List<ItemModel> Items { get; set; }

        public NonPlayerCharacterModel(NonPlayerCharacter original) : base(original)
        {
        }
    }
}
