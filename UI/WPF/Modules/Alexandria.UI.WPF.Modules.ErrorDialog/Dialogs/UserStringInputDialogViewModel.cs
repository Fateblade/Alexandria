using Fateblade.Alexandria.UI.WPF.Base;
using Prism.Commands;
using System.Windows.Input;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    internal class UserStringInputDialogViewModel : BindableDialogBase<UserStringInputDialogCreationInformation, UserStringInputDialogResultInformation>
    {
        private string _question;
        public string Question
        {
            get => _question;
            set => SetProperty(ref _question, value);
        }

        private string _userInput;
        public string UserInput
        {
            get => _userInput;
            set => SetProperty(ref _userInput, value);
        }

        public ICommand UserConfirmedCommand { get; }
        public ICommand UserAbortedCommand { get; }

        public UserStringInputDialogViewModel()
        {
            UserConfirmedCommand = new DelegateCommand(confirmDialog, canConfirmDialog)
                .ObservesProperty(()=>UserInput);
            UserAbortedCommand = new DelegateCommand(abortDialog);
        }

        protected override void InitializeDialog(UserStringInputDialogCreationInformation information)
        {
            Question = information.Question;
        }

        private bool canConfirmDialog()
        {
            return !string.IsNullOrWhiteSpace(UserInput);
        }

        private void confirmDialog()
        {
            RaiseRequestDialogClose(new UserStringInputDialogResultInformation(UserInput, true));
        }

        private void abortDialog()
        {
            RaiseRequestDialogClose(new UserStringInputDialogResultInformation(null, false));
        }

    }
}
