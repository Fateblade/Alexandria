using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;
using System.Drawing;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class TagModel : ModifiableDataClassModel<Tag>
    {
        public IIdentifiableGuidEntity AssociatedObject { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }

        public TagModel(Tag original) : base(original)
        {
        }
    }
}
