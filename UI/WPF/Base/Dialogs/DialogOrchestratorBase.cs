using Prism.Services.Dialogs;

namespace Fateblade.Alexandria.UI.WPF.Base.Dialogs
{
    public abstract class DialogOrchestratorBase
    {
        protected IDialogService DialogService { get; }

        protected DialogOrchestratorBase(IDialogService dialogService)
        {
            DialogService = dialogService;
        }
    }
}
