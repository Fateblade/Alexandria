using Fateblade.Components.Logic.Foundation.Orchestration.Contract.DataClasses;
using System;

namespace Fateblade.Alexandria.UI.WPF.Base.Navigation
{
    public class AddToNavigationTrailOrchestrationInfo : OrchestrationBaseInfo
    {
        public string TrailToDisplay { get; set; }
        public Guid TrailStepId { get; set; }
    }

    public class TrailBackNavigationOnceOrchestrationMessage : OrchestrationBaseInfo
    {
    }
}