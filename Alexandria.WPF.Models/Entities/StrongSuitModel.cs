using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Models.Base;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class StrongSuitModel : ModifiableDataClassModel<StrongSuit>
    {
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }

        public StrongSuitModel(StrongSuit original) : base(original)
        {
        }
    }
}