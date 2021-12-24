using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    class ErrorDialogCreationInformation : DialogCreationInformation
    {
        public string Message { get; }

        public ErrorDialogCreationInformation(string title, string message)
        {
            Title = title;
            Message = message;
        }
    }
}