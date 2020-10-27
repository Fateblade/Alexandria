using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Models.Base;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class LinkModel : ModifiableDataClassModel<Link>
    {
        public IIdentifiableGuidEntity AssociatedObject { get; set; }
        public LinkType Type { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }

        public LinkModel(Link original) : base(original)
        {
        }
    }
}
