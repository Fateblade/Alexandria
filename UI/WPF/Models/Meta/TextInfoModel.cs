using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class TextInfoModel : ModifiableIdentifiableDataClassModel<TextInfo>
    {
        public IIdentifiableGuidEntity AssociatedObject { get; set; }
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }

        public override TextInfo ModifiedEntity => throw new System.NotImplementedException();

        public TextInfoModel(TextInfo original) : base(original)
        {
            ShortInfo = original.ShortInfo;
            LongInfo = original.LongInfo;
        }

        public override void ModifyOriginalEntity()
        {
            throw new System.NotImplementedException();
        }
    }
}
