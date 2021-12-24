using Fateblade.Alexandria.UI.WPF.Client.Dialogs;
using Prism.Services.Dialogs;
using System;

namespace Fateblade.Alexandria.UI.WPF.Client
{
    class CommonDialogOrchestrator : ICommonDialogOrchestrator
    {
        private readonly IDialogService _dialogService;

        public CommonDialogOrchestrator(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public void GetUserConfirmation(string confirmationQuestion, Action<bool> confirmationCallback)
        {
            var parameters = new DialogParameters
            {
                {nameof(UserConfirmationDialogCreationInformation), new UserConfirmationDialogCreationInformation(confirmationQuestion)}
            };

            _dialogService.ShowDialog(
                nameof(UserConfirmationDialog),
                parameters,
                result =>
                {
                    confirmationCallback.Invoke(result is UserConfirmationDialogResultInformation {UserConfirmed: false});
                });
        }

        public void ShowErrorDialog(string errorMessage, string errorTitle)
        {
            var parameters = new DialogParameters
            {
                {nameof(ErrorDialogCreationInformation), new ErrorDialogCreationInformation(errorTitle, errorMessage)}
            };

            _dialogService.Show(nameof(ErrorMessageDialog), parameters, _ => { });
        }
    }
}
