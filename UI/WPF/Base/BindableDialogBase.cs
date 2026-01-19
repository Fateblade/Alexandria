using Prism.Services.Dialogs;
using System;
using Prism.Mvvm;

namespace Fateblade.Alexandria.UI.WPF.Base
{
    public abstract class DialogCreationInformation
    {
        public string Title { get; protected set; }
    }

    public abstract class DialogResultInformation : IDialogResult
    {
        public IDialogParameters Parameters { get; protected set; }
        public ButtonResult Result { get; protected set; }
    }

    public abstract class BindableDialogBase<TCreationInformation, TResultInformation> : BindableBase, IDialogAware 
        where TCreationInformation: DialogCreationInformation
        where TResultInformation : DialogResultInformation
    {
        public event Action<IDialogResult> RequestClose;

        private string _title;
        public string Title
        {
            get => _title;
            private set => SetProperty(ref _title, value);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (!parameters.ContainsKey(typeof(TCreationInformation).Name))
            {
                throw new ArgumentException("Missing information to create dialog", nameof(TCreationInformation));
            }

            TCreationInformation creationInformation = parameters.GetValue<TCreationInformation>(typeof(TCreationInformation).Name);
            Title = creationInformation.Title;

            InitializeDialog(creationInformation);
        }

        protected abstract void InitializeDialog(TCreationInformation information);

        protected void RaiseRequestDialogClose(TResultInformation dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }
    }
}
