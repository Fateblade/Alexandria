using System.Windows;
using System.Windows.Input;
using Fateblade.Alexandria.UI.WPF.Base;
using Prism.Commands;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    public class ErrorMessageDialogViewModel : BindableDialogBase<ErrorDialogCreationInformation, ErrorDialogResultInformation>
    {
        private string _message;
        public string Message
        {
            get => _message;
            private set => SetProperty(ref _message, value);
        }

        public ICommand CopyToClipboardCommand { get; }
        public ICommand CloseDialogCommand { get; }

        public ErrorMessageDialogViewModel()
        {
            CopyToClipboardCommand = new DelegateCommand(copyMessageToClipboard);
            CloseDialogCommand = new DelegateCommand(closeDialog);
        }

        protected override void InitializeDialog(ErrorDialogCreationInformation information)
        {
            Message = information.Message;
        }

        private void copyMessageToClipboard()
        {
            Clipboard.Clear();
            Clipboard.SetText(Message);
        }

        private void closeDialog()
        {
            RaiseRequestDialogClose(new ErrorDialogResultInformation());
        }

    }
}