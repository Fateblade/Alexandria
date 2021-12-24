using Fateblade.Alexandria.UI.WPF.Client.Dialogs;
using Prism.Ioc;
using Prism.Modularity;

namespace Fateblade.Alexandria.UI.WPF.Client
{
    public class CommonDialogsModule : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<ErrorMessageDialog, ErrorMessageDialogViewModel>();
            containerRegistry.RegisterDialog<UserConfirmationDialog, UserConfirmationDialogViewModel>();
            containerRegistry.RegisterSingleton<ICommonDialogOrchestrator, CommonDialogOrchestrator>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }
    }
}
