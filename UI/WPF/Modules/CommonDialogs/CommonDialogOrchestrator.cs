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
                {nameof(UserConfirmationDialogRequest), new UserConfirmationDialogRequest(confirmationQuestion)}
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
                {nameof(ErrorDialogRequest), new ErrorDialogRequest(errorTitle, errorMessage)}
            };

            DialogService.Show(nameof(ErrorMessageDialog), parameters, _ => { });
        }

        public void GetStringUserInput(string question, string title, Action<string> userInputCallback)
        {
            var parameters = new DialogParameters
            {
                { nameof(UserStringInputDialogRequest), new UserStringInputDialogRequest(question, title) }
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
                { nameof(UserStringInputDialogRequest), new UserStringInputDialogRequest(question, defaultValue, title) }
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
                { nameof(InfoDialogRequest), new InfoDialogRequest(title, infoText) }
            };

            DialogService.ShowDialog(nameof(InfoDialog), parameters, _ => { });
        }

        public void GetIntUserInput(string question, string title, Action<int> userInputCallback)
        {
            var parameters = new DialogParameters
            {
                { nameof(UserNumberInputDialogRequest), new UserNumberInputDialogRequest(question, title) }
            };

            DialogService.ShowDialog(
                nameof(UserNumberInputDialog),
                parameters,
                result =>
                {
                    if (result is UserNumberInputDialogResult dialogResult
                        && dialogResult.Result == ButtonResult.Yes
                        && dialogResult.UserInput.HasValue)
                    {
                        userInputCallback.Invoke(dialogResult.UserInput.Value);
                    }
                });
        }

        public void GetIntUserInput(string question, int defaultValue, string title, Action<int> userInputCallback)
        {
            var parameters = new DialogParameters
            {
                { nameof(UserNumberInputDialogRequest), new UserNumberInputDialogRequest(question, defaultValue, title) }
            };

            DialogService.ShowDialog(
                nameof(UserNumberInputDialog),
                parameters,
                result =>
                {
                    if (result is UserNumberInputDialogResult dialogResult 
                        && dialogResult.Result == ButtonResult.Yes
                        && dialogResult.UserInput.HasValue)
                    {
                        userInputCallback.Invoke(dialogResult.UserInput.Value);
                    }
                });
        }
    }

}
