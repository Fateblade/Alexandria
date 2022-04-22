using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class GoalModel : ModifiableDataClassModel<Goal>
    {
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }

        public override Goal ModifiedEntity => throw new System.NotImplementedException();

        public GoalModel(Goal original) : base(original)
        {
        }

        public override void ModifyOriginalEntity()
        {
            throw new System.NotImplementedException();
        }
    }
}