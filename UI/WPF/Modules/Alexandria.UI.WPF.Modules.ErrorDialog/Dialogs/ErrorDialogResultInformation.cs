using Fateblade.Alexandria.UI.WPF.Base;
using Prism.Services.Dialogs;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    public class ErrorDialogResultInformation : DialogResultInformation
    {
        public ErrorDialogResultInformation()
        {
            Parameters = new DialogParameters();
            Result = ButtonResult.OK;
        } 
    }
}