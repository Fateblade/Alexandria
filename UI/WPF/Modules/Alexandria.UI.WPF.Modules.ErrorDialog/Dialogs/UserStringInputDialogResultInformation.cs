using Fateblade.Alexandria.UI.WPF.Base;
using Prism.Services.Dialogs;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    internal class UserStringInputDialogResultInformation : DialogResultInformation
    {
        public string UserInput { get; }

        public UserStringInputDialogResultInformation(string userInput, bool userConfirmed)
        {
            UserInput = userInput;
            Result = userConfirmed ? ButtonResult.Yes : ButtonResult.No;
        }
    }
}