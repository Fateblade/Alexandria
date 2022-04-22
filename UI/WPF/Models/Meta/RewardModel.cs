using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class RewardModel : ModifiableDataClassModel<Reward>
    {
        public string RewardInformation { get; set; }
        public bool Received { get; set; }

        public override Reward ModifiedEntity => throw new System.NotImplementedException();

        public RewardModel(Reward original) : base(original)
        {
        }

        public override void ModifyOriginalEntity()
        {
            throw new System.NotImplementedException();
        }
    }
}
