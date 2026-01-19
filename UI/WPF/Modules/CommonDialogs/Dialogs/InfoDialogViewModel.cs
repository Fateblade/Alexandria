using Fateblade.Alexandria.UI.WPF.Base;
using Prism.Commands;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    internal class InfoDialogRequest : DialogCreationInformation
    {
        public string InfoText { get; set; }

        public InfoDialogRequest(string title, string infoText)
        {
            Title = title;
            InfoText = infoText;
        }
    }

    internal class InfoDialogResultInformation : DialogResultInformation
    {

    }

    internal class InfoDialogViewModel : BindableDialogBase<InfoDialogRequest, InfoDialogResultInformation>
    {
        private string _infoText;
        public string InfoText
        {
            get => _infoText;
            set => SetProperty(ref _infoText, value);
        }

        public DelegateCommand CloseDialogCommand { get; }

        public InfoDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand(closeDialog);
        }

        protected override void InitializeDialog(InfoDialogRequest information)
        {
            InfoText = information.InfoText;
        }

        private void closeDialog()
        {
            RaiseRequestDialogClose(new InfoDialogResultInformation());
        }

    }
}
