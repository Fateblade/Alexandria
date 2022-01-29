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
                    if (result is UserConfirmationDialogResultInformation dialogResult)
                    {
                        confirmationCallback.Invoke(dialogResult.UserConfirmed);
                    }
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

        public void GetStringUserInput(string question, string title, Action<string> userInputCallback)
        {
            var parameters = new DialogParameters
            {
                { nameof(UserStringInputDialogCreationInformation), new UserStringInputDialogCreationInformation(question, title) }
            };

            _dialogService.ShowDialog(
                nameof(UserStringInputDialog),
                parameters,
                result =>
                {
                    if (result is UserStringInputDialogResultInformation dialogResult && dialogResult.Result == ButtonResult.Yes)
                    {
                        userInputCallback.Invoke(dialogResult.UserInput); 
                    }
                });
        }
    }

}
