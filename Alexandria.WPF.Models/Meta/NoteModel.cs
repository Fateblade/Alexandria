using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class NoteModel : ModifiableDataClassModel<Note>
    {
        public IIdentifiableGuidEntity AssociatedObject { get; set; }
        public string Description { get; set; }

        public NoteModel(Note original) : base(original)
        {
        }
    }
}
