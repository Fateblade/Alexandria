using System.Collections.ObjectModel;

namespace Alexandria.WPF.Models.Meta
{
    public enum EncounterType { Fight, Social, Exploration, Other}
    public enum EncounterState { Success, Failure, Unexplored, NeutralOutcome }

    public class Encounter : BaseObject, ISummarizable
    {
        private EncounterType _Type;
        public EncounterType Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        private ObservableCollection<Monster> _ParticipatingMonsters;
        public ObservableCollection<Monster> ParticipatingMonsters
        {
            get { return _ParticipatingMonsters; }
            set { SetProperty(ref _ParticipatingMonsters, value); }
        }

        private ObservableCollection<NonPlayerCharacter> _ParticipatingNpcs;
        public ObservableCollection<NonPlayerCharacter> ParticipatingNpcs
        {
            get { return _ParticipatingNpcs; }
            set { SetProperty(ref _ParticipatingNpcs, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        private string _Summary;
        public string Summary
        {
            get { return _Summary; }
            set { SetProperty(ref _Summary, value); }
        }

        private string _Reward;
        public string Reward
        {
            get { return _Reward; }
            set { SetProperty(ref _Reward, value); }
        }

        private string _ConsequenceSuccess;
        public string ConsequenceSucces
        {
            get { return _ConsequenceSuccess; }
            set { SetProperty(ref _ConsequenceSuccess, value); }
        }

        private string _ConsequenceFailure;
        public string ConsequenceFailure
        {
            get { return _ConsequenceFailure; }
            set { SetProperty(ref _ConsequenceFailure, value); }
        }

        private EncounterState _State;
        public EncounterState State
        {
            get { return _State; }
            set { SetProperty(ref _State, value); }
        }
    }
}
