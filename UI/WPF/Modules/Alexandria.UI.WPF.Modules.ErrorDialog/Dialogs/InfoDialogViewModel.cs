using Fateblade.Alexandria.UI.WPF.Base;

namespace Fateblade.Alexandria.UI.WPF.Client.Dialogs
{
    internal class InfoDialogCreationInformation : DialogCreationInformation
    {
        public string InfoText { get; set; }

        public InfoDialogCreationInformation(string title, string infoText)
        {
            Title = title;
            InfoText = infoText;
        }
    }

    internal class InfoDialogResultInformation : DialogResultInformation
    {

    }

    internal class InfoDialogViewModel : BindableDialogBase<InfoDialogCreationInformation, InfoDialogResultInformation>
    {
        private string _infoText;
        public string InfoText
        {
            get => _infoText;
            set => SetProperty(ref _infoText, value);
        }

        protected override void InitializeDialog(InfoDialogCreationInformation information)
        {
            InfoText = information.InfoText;
        }
    }
}
