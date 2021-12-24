using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    class UserConfirmationDialogCreationInformation : DialogCreationInformation
    {
        public string ConfirmationQuestion { get; }

        public UserConfirmationDialogCreationInformation(string confirmationQuestion)
        {
            ConfirmationQuestion = confirmationQuestion;
            Title = "Confirmation";
        }
    }
}
