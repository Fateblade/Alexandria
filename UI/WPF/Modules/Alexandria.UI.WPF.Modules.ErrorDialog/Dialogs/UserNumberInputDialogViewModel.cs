using Fateblade.Alexandria.UI.WPF.Base;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    public class UserNumberInputDialogRequest : DialogCreationInformation
    {
        public string Question { get; }
        public int? DefaultValue { get; set; }

        public UserNumberInputDialogRequest(string question, string title)
        {
            Question = question;
            Title = title;
        }

        public UserNumberInputDialogRequest(string question, int defaultValue, string title)
        {
            Question = question;
            DefaultValue = defaultValue;
            Title = title;
        }
    }

    public class UserNumberInputDialogResult : DialogResultInformation
    {
        public int? UserInput { get; }

        public UserNumberInputDialogResult(int userInput)
        {
            UserInput = userInput;
            Result = ButtonResult.Yes;
        }

        public UserNumberInputDialogResult()
        {
            UserInput = null;
            Result = ButtonResult.No;
        }
    }

    internal class UserNumberInputDialogViewModel :BindableDialogBase<UserNumberInputDialogRequest, UserNumberInputDialogResult>
    {
        private string _question;
        public string Question
        {
            get => _question;
            set => SetProperty(ref _question, value);
        }

        private int _value;
        public int Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public DelegateCommand AcceptInputCommand { get; }
        public DelegateCommand AbortDialogCommand { get; }


        public UserNumberInputDialogViewModel()
        {
            AcceptInputCommand = new DelegateCommand(acceptInput);
            AbortDialogCommand = new DelegateCommand(abortDialog);
        }


        private void acceptInput()
        {
            RaiseRequestDialogClose(new UserNumberInputDialogResult(Value));
        }

        private void abortDialog()
        {
            RaiseRequestDialogClose(new UserNumberInputDialogResult());
        }


        protected override void InitializeDialog(UserNumberInputDialogRequest information)
        {
            Question = information.Question;
            Value = information.DefaultValue ?? 0;
        }
    }

}
