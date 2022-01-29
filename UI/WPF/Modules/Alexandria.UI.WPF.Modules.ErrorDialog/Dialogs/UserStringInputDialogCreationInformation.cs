using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    internal class UserStringInputDialogCreationInformation : DialogCreationInformation
    {
        public string Question { get; }

        public UserStringInputDialogCreationInformation(string question, string title)
        {
            Question = question;
            Title = title;
        }
    }
}
