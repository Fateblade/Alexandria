using System;
using Fateblade.Components.Logic.Foundation.Orchestration.Contract.DataClasses;
using Prism.Mvvm;

namespace Fateblade.Alexandria.UI.WPF.Base.Messages
{
    public class ShowPageOrchestrationInfo : OrchestrationBaseInfo
    {
        public BindableBase PageViewModelToDisplay { get; set; }
        public Action<BindableBase> HandlePageClosed { get; set; }
    }
}
