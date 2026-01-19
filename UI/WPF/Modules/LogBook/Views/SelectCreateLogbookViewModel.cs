using System;
using System.Collections.Generic;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Alexandria.UI.WPF.Modules.LogBook.Messages;

namespace Fateblade.Alexandria.UI.WPF.Modules.LogBook.Views
{
    internal class SelectCreateLogbookViewModel : BindableBase
    {
        private readonly IEventBroker _eventBroker;

        private Logbook _selectedLogbook;
        public Logbook SelectedLogbook
        {
            get => _selectedLogbook;
            set => SetProperty(ref _selectedLogbook, value);
        }

        private ObservableCollection<Logbook> _existingLogbooks;
        public ObservableCollection<Logbook> ExistingLogbooks
        {
            get => _existingLogbooks;
            set => SetProperty(ref _existingLogbooks, value);
        }

        public DelegateCommand CreateNewLogbookCommand { get; }
        public DelegateCommand DeleteLogbookCommand { get; }
        public DelegateCommand OpenLogbookCommand { get; }

        public SelectCreateLogbookViewModel(IEventBroker eventBroker)
        {
            _eventBroker = eventBroker;
            CreateNewLogbookCommand = new DelegateCommand(() =>
            {
                ExistingLogbooks.Add(new Logbook()
                {
                    Id = Guid.NewGuid(), 
                    Name = new Random().Next(3, 80).ToString()
                });
            });

            DeleteLogbookCommand = new DelegateCommand(
                    () =>
                    {
                        ExistingLogbooks.Remove(SelectedLogbook);
                        SelectedLogbook = null;
                    },
                    () => SelectedLogbook != null
                )
                .ObservesProperty(() => SelectedLogbook);

            OpenLogbookCommand = new DelegateCommand(
                    () =>
                    {
                        _eventBroker.Raise(new OpenLogbookMessage(SelectedLogbook));
                    },
                    () => SelectedLogbook != null
                )
                .ObservesProperty(() => SelectedLogbook);
        }
    }


    /// <summary>
    /// needs to be in CrossCutting package
    /// </summary>
    public class Logbook
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class LogbookEntry
    {
        public Guid Id { get; set; }
        public Guid LogbookId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
    }
}
