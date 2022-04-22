using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Models.Entities
{
    public class AmbitionModel : ModifiableDataClassModel<Ambition>
    {
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }

        public override Ambition ModifiedEntity => throw new System.NotImplementedException();

        public AmbitionModel(Ambition original) : base(original)
        {
        }

        public override void ModifyOriginalEntity()
        {
            throw new System.NotImplementedException();
        }
    }
}