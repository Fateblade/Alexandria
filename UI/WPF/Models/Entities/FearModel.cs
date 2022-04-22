using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class FearModel : ModifiableDataClassModel<Fear>
    {
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }

        public override Fear ModifiedEntity => throw new System.NotImplementedException();

        public FearModel(Fear original) : base(original)
        {
        }

        public override void ModifyOriginalEntity()
        {
            throw new System.NotImplementedException();
        }
    }
}