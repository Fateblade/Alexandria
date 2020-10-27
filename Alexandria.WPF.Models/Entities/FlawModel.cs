using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Models.Base;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class FlawModel : ModifiableDataClassModel<Flaw>
    {
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }

        public FlawModel(Flaw original) : base(original)
        {
        }
    }
}