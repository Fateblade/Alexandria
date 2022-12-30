using Fateblade.Alexandria.UI.WPF.Client.Dialogs;
using Prism.Services.Dialogs;
using System;
using Fateblade.Alexandria.UI.WPF.Base.Dialogs;

namespace Fateblade.Alexandria.UI.WPF.Client
{
    class CommonDialogOrchestrator : DialogOrchestratorBase, ICommonDialogOrchestrator
    {
        public CommonDialogOrchestrator(IDialogService dialogService) 
            : base(dialogService) { }

        public void GetUserConfirmation(string confirmationQuestion, Action<bool> confirmationCallback)
        {
            var parameters = new DialogParameters
            {
                {nameof(UserConfirmationDialogCreationInformation), new UserConfirmationDialogCreationInformation(confirmationQuestion)}
            };

            DialogService.ShowDialog(
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

            DialogService.Show(nameof(ErrorMessageDialog), parameters, _ => { });
        }

        public void GetStringUserInput(string question, string title, Action<string> userInputCallback)
        {
            var parameters = new DialogParameters
            {
                { nameof(UserStringInputDialogCreationInformation), new UserStringInputDialogCreationInformation(question, title) }
            };

            DialogService.ShowDialog(
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

        public void GetStringUserInput(string question, string defaultValue, string title,
            Action<string> userInputCallback)
        {
            var parameters = new DialogParameters
            {
                { nameof(UserStringInputDialogCreationInformation), new UserStringInputDialogCreationInformation(question, defaultValue, title) }
            };

            DialogService.ShowDialog(
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

        public void ShowInfoDialog(string infoText, string title)
        {
            var parameters = new DialogParameters
            {
                { nameof(InfoDialogCreationInformation), new InfoDialogCreationInformation(title, infoText) }
            };

            DialogService.ShowDialog(nameof(InfoDialog), parameters, _ => { });
        }
    }

}
