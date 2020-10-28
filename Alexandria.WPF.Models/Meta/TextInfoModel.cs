using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class TextInfoModel : ModifiableDataClassModel<TextInfo>
    {
        public IIdentifiableGuidEntity AssociatedObject { get; set; }
        public string ShortInfo { get; set; }
        public string LongInfo { get; set; }

        public TextInfoModel(TextInfo original) : base(original)
        {
        }
    }
}
