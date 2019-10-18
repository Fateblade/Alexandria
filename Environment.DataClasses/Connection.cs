using System;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class Connection
    {
        public int ConnectionStatusID { get; set; }
        public int ConnectionDirectionTypeID { get; set; }
        public string ConnenctionType { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public Guid SourceID { get; set; }
        public Guid TargetID { get; set; }
    }
}
