using Fateblade.Alexandria.UI.WPF.Base;
using Prism.Commands;
using System.Windows.Input;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    class UserConfirmationDialogRequest : DialogCreationInformation
    {
        public string ConfirmationQuestion { get; }

        public UserConfirmationDialogRequest(string confirmationQuestion)
        {
            ConfirmationQuestion = confirmationQuestion;
            Title = "Confirmation";
        }
    }

    class UserConfirmationDialogResultInformation : DialogResultInformation
    {
        public bool UserConfirmed { get; }

        public UserConfirmationDialogResultInformation(bool userConfirmed)
        {
            UserConfirmed = userConfirmed;
        }
    }

    class UserConfirmationDialogViewModel : BindableDialogBase<UserConfirmationDialogRequest, UserConfirmationDialogResultInformation>
    {
        private string _confirmationQuestion;
        public string ConfirmationQuestion
        {
            get => _confirmationQuestion;
            set => SetProperty(ref _confirmationQuestion, value);
        }

        public ICommand UserConfirmedCommand { get; }
        public ICommand UserAbortedCommand { get; }

        public UserConfirmationDialogViewModel()
        {
            UserConfirmedCommand = new DelegateCommand(confirmDialog);
            UserAbortedCommand = new DelegateCommand(abortDialog);
        }

        protected override void InitializeDialog(UserConfirmationDialogRequest information)
        {
            ConfirmationQuestion = information.ConfirmationQuestion;
        }

        private void confirmDialog()
        {
            RaiseRequestDialogClose(new UserConfirmationDialogResultInformation(true));
        }

        private void abortDialog()
        {
            RaiseRequestDialogClose(new UserConfirmationDialogResultInformation(false));
        }

    }
}
