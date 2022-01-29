using System;

namespace Fateblade.Alexandria.UI.WPF.Client
{
    public interface ICommonDialogOrchestrator
    {
        void GetUserConfirmation(string confirmationQuestion, Action<bool> confirmationCallback);
        void ShowErrorDialog(string errorMessage, string errorTitle);
        void GetStringUserInput(string question, string title, Action<string> userInputCallback);
    }
}