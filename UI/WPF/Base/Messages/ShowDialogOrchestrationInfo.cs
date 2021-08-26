using System;
using Fateblade.Components.Logic.Foundation.Orchestration.Contract.DataClasses;
using Prism.Mvvm;

namespace Fateblade.Alexandria.UI.WPF.Base.Messages
{
    public class ShowDialogOrchestrationInfo : OrchestrationBaseInfo
    {
        public BindableBase DialogViewModelToDisplay { get; set; }
        public Action<BindableBase> HandleDialogClosed { get; set; }
    }
}
