using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using Fateblade.Alexandria.UI.WPF.Base;
using System.Collections.Generic;

namespace Fateblade.Alexandria.UI.WPF.Models.Environment
{
    public class PlaneModel : ModifiableDataClassModel<Plane>
    {
        public List<ConnectionModel> Connections { get; set; } = new List<ConnectionModel>();
        public string Summary { get; set; }
        public string Features { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationModel SubLocationOf { get; set; }

        public PlaneModel(Plane original) : base(original)
        {
        }
    }
}
