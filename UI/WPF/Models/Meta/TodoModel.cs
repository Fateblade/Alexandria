using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    public class TodoModel : ModifiableDataClassModel<Todo>
    {
        public IIdentifiableGuidEntity AssociatedObjectId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }

        public override Todo ModifiedEntity => throw new System.NotImplementedException();

        public TodoModel(Todo original) : base(original)
        {
        }

        public override void ModifyOriginalEntity()
        {
            throw new System.NotImplementedException();
        }
    }
}
