using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    internal class UserStringInputDialogCreationInformation : DialogCreationInformation
    {
        public string Question { get; }
        public string DefaultValue { get; set; }

        public UserStringInputDialogCreationInformation(string question, string title)
        {
            Question = question;
            Title = title;
        }

        public UserStringInputDialogCreationInformation(string question, string defaultValue, string title)
        {
            Question = question;
            DefaultValue = defaultValue;
            Title = title;
        }
    }
}
