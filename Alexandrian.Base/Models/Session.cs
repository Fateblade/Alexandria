using System;
using System.Collections.ObjectModel;

namespace Alexandrian.Base.Models
{
    public class Session : BaseObject
    {
        private string _Summary;
        public string Summary
        {
            get { return _Summary; }
            set { SetProperty(ref _Summary, value); }
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private DateTime _PlayDate;
        public DateTime PlayDate
        {
            get { return _PlayDate; }
            set { SetProperty(ref _PlayDate, value); }
        }

        private ObservableCollection<Character> _ParticipatingCharacters;
        public ObservableCollection<Character> ParticipatingCharacters
        {
            get { return _ParticipatingCharacters; }
            set { SetProperty(ref _ParticipatingCharacters, value); }
        }

        private ObservableCollection<Adventure> _PlayedAdventures;
        public ObservableCollection<Adventure> PlayedAdventures
        {
            get { return _PlayedAdventures; }
            set { SetProperty(ref _PlayedAdventures, value); }
        }

        private ObservableCollection<Stage> _PlayedStages;
        public ObservableCollection<Stage> PlayedStages
        {
            get { return _PlayedStages; }
            set { SetProperty(ref _PlayedStages, value); }
        }

        private ObservableCollection<Encounter> _PlayedEncounters;
        public ObservableCollection<Encounter> PlayedEncounters
        {
            get { return _PlayedEncounters; }
            set { SetProperty(ref _PlayedEncounters, value); }
        }
    }
}
