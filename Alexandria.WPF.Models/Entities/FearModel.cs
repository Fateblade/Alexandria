using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Models.Base;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class FearModel : ModifiableDataClassModel<Fear>
    {
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }

        public FearModel(Fear original) : base(original)
        {
        }
    }
}