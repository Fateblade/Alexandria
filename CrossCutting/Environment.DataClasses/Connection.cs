using System;
using Fateblade.Components.CrossCutting.Base.Identifiable.DataClasses;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class Connection : IIdentifiableGuidEntity
    {
        public Guid Id { get; set; }
        public ConnectionStatus ConnectionStatus { get; set; }
        public ConnectionDirectionType ConnectionDirectionType { get; set; }
        public string ConnenctionType { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public Guid SourceObjectId { get; set; }
        public string SourceObjectType { get; set; }
        public Guid TargetObjectId { get; set; }
        public string TargetObjectType { get; set; }
    }
}
