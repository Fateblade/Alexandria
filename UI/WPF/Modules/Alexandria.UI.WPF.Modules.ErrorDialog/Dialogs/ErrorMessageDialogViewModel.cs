﻿using System.Windows;
using System.Windows.Input;
using Fateblade.Alexandria.UI.WPF.Base;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    class ErrorDialogRequest : DialogCreationInformation
    {
        public string Message { get; }

        public ErrorDialogRequest(string title, string message)
        {
            Title = title;
            Message = message;
        }
    }

    class ErrorDialogResultInformation : DialogResultInformation
    {
        public ErrorDialogResultInformation()
        {
            Parameters = new DialogParameters();
            Result = ButtonResult.OK;
        }
    }

    class ErrorMessageDialogViewModel : BindableDialogBase<ErrorDialogRequest, ErrorDialogResultInformation>
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

        protected override void InitializeDialog(ErrorDialogRequest information)
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