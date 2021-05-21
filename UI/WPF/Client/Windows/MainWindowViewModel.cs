using Prism.Mvvm;
using System;
using Prism.Commands;

namespace Fateblade.Alexandria.UI.WPF.Client.Windows
{
    class MainWindowViewModel : BindableBase
    {
        public DelegateCommand ThrowExceptionCommand { get; }

        public MainWindowViewModel()
        {
            ThrowExceptionCommand = new DelegateCommand(() => throw new Exception("Blub"));
        }
    }
}
