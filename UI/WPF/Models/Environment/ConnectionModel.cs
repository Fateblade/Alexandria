using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.UI.WPF.Models.Environment
{
    public class ConnectionModel : ModifiableDataClassModel<Connection>
    {
        public ConnectionStatus ConnectionStatus { get; set; }
        public ConnectionDirectionType ConnectionDirectionType { get; set; }
        public string ConnenctionType { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public IIdentifiableGuidEntity SourceObjectId { get; set; }
        public IIdentifiableGuidEntity TargetObjectId { get; set; }

        public ConnectionModel(Connection original) : base(original)
        {
        }
    }
}
