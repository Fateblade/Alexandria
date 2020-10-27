using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Models.Base;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class GoalModel : ModifiableDataClassModel<Goal>
    {
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }

        public GoalModel(Goal original) : base(original)
        {
        }
    }
}