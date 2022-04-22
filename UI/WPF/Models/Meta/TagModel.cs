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

        public override Tag ModifiedEntity => throw new System.NotImplementedException();

        public TagModel(Tag original) : base(original)
        {
        }

        public override void ModifyOriginalEntity()
        {
            throw new System.NotImplementedException();
        }
    }
}
