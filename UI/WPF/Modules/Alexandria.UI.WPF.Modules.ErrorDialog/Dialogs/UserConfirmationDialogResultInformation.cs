using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    class UserConfirmationDialogResultInformation : DialogResultInformation
    {
        public bool UserConfirmed { get; }

        public UserConfirmationDialogResultInformation(bool userConfirmed)
        {
            UserConfirmed = userConfirmed;
        }
    }
}
