using System;
using Fateblade.Components.Logic.Foundation.Orchestration.Contract.DataClasses;
using Prism.Mvvm;

namespace Fateblade.Alexandria.UI.WPF.Base.Messages
{
    public class ShowExistingPageOrchestrationInfo : OrchestrationBaseInfo
    {
        public BindableBase PageViewModelToDisplay { get; set; }
        public Action<BindableBase> HandlePageClosed { get; set; }

        public ShowExistingPageOrchestrationInfo(BindableBase pageViewModelToDisplay)
        {
            PageViewModelToDisplay = pageViewModelToDisplay;
        }

        public ShowExistingPageOrchestrationInfo(BindableBase pageViewModelToDisplay, Action<BindableBase> handlePageClosed)
        {
            PageViewModelToDisplay = pageViewModelToDisplay;
            HandlePageClosed = handlePageClosed;
        }
    }

    public class ShowPageOrchestrationInfo : OrchestrationBaseInfo
    {
        public Type PageViewModelTypeToDisplay { get; set; }
        public Action<BindableBase> HandlePageClosed { get; set; }

        public ShowPageOrchestrationInfo(Type pageViewModelTypeToDisplay)
        {
            PageViewModelTypeToDisplay = pageViewModelTypeToDisplay;
        }

        public ShowPageOrchestrationInfo(Type pageViewModelTypeToDisplay, Action<BindableBase> handlePageClosed)
        {
            PageViewModelTypeToDisplay = pageViewModelTypeToDisplay;
            HandlePageClosed = handlePageClosed;
        }
    }
}
