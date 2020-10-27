using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Models.Base;
using Fateblade.Alexandria.UI.WPF.Models.Environment;
using Fateblade.Alexandria.UI.WPF.Models.Gear;
using System;
using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class DeityModel : ModifiableDataClassModel<Deity>
    {
        public string Aspects { get; set; }
        public int RelationCategoryId => (int)RelationCategory.Deity;
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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Statistics { get; set; }
        public Guid SystemId { get; set; }
        public List<ItemModel> Items { get; set; }
        public PlaneModel Homeplanes { get; set; }

        public DeityModel(Deity original) : base(original)
        {
        }
    }
}
