using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Models.Environment
{
    public class LocationModel : ModifiableDataClassModel<Location>
    {
        public List<ConnectionModel> Connections { get; set; } = new List<ConnectionModel>();
        public string Summary { get; set; }
        public string Features { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationModel SubLocationOf { get; set; }

        public override Location ModifiedEntity => throw new System.NotImplementedException();

        public LocationModel(Location original) : base(original)
        {
        }

        public override void ModifyOriginalEntity()
        {
            throw new System.NotImplementedException();
        }
    }
}
