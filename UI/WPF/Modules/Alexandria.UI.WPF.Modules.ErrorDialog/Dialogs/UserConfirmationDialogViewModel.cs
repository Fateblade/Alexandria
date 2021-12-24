using Fateblade.Alexandria.UI.WPF.Base;
using Prism.Commands;
using System.Windows.Input;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    class UserConfirmationDialogViewModel : BindableDialogBase<UserConfirmationDialogCreationInformation, UserConfirmationDialogResultInformation>
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

        protected override void InitializeDialog(UserConfirmationDialogCreationInformation information)
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
