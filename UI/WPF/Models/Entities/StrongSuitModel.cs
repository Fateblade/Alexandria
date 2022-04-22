using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class StrongSuitModel : ModifiableDataClassModel<StrongSuit>
    {
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }

        public override StrongSuit ModifiedEntity => throw new System.NotImplementedException();

        public StrongSuitModel(StrongSuit original) : base(original)
        {
        }

        public override void ModifyOriginalEntity()
        {
            throw new System.NotImplementedException();
        }
    }
}