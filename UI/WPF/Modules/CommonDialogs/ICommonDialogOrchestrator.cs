using System;

namespace Fateblade.Alexandria.UI.WPF.Client
{
    public interface ICommonDialogOrchestrator
    {
        void GetUserConfirmation(string confirmationQuestion, Action<bool> confirmationCallback);
        void ShowErrorDialog(string errorMessage, string errorTitle);
        void GetStringUserInput(string question, string title, Action<string> userInputCallback);
        void GetStringUserInput(string question, string defaultValue, string title, Action<string> userInputCallback);
        void GetIntUserInput(string question, string title, Action<int> userInputCallback);
        void GetIntUserInput(string question, int defaultValue, string title, Action<int> userInputCallback);
        void ShowInfoDialog(string infoText, string title);
    }
}