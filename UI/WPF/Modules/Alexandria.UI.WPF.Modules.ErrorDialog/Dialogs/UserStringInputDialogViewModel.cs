using Fateblade.Alexandria.UI.WPF.Base;
using Prism.Commands;
using System.Windows.Input;
using Prism.Services.Dialogs;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    internal class UserStringInputDialogRequest : DialogCreationInformation
    {
        public string Question { get; }
        public string DefaultValue { get; set; }

        public UserStringInputDialogRequest(string question, string title)
        {
            Question = question;
            Title = title;
        }

        public UserStringInputDialogRequest(string question, string defaultValue, string title)
        {
            Question = question;
            DefaultValue = defaultValue;
            Title = title;
        }
    }

    internal class UserStringInputDialogResultInformation : DialogResultInformation
    {
        public string UserInput { get; }

        public UserStringInputDialogResultInformation(string userInput, bool userConfirmed)
        {
            UserInput = userInput;
            Result = userConfirmed ? ButtonResult.Yes : ButtonResult.No;
        }
    }

    internal class UserStringInputDialogViewModel : BindableDialogBase<UserStringInputDialogRequest, UserStringInputDialogResultInformation>
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

        protected override void InitializeDialog(UserStringInputDialogRequest information)
        {
            Question = information.Question;
            UserInput = information.DefaultValue;
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