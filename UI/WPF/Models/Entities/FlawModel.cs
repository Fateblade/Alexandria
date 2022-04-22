using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class FlawModel : ModifiableDataClassModel<Flaw>
    {
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }

        public override Flaw ModifiedEntity => throw new System.NotImplementedException();

        public FlawModel(Flaw original) : base(original)
        {
        }

        public override void ModifyOriginalEntity()
        {
            throw new System.NotImplementedException();
        }
    }
}