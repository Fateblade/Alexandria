using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Alexandria.WPF.Models.Meta
{
    public class Adventure : BaseObject, ISummarizable
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
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

        private string _AdditionalReward;
        public string AdditionalReward
        {
            get { return _AdditionalReward; }
            set { SetProperty(ref _AdditionalReward, value); }
        }

        private ObservableCollection<string> _RewardSummary;
        public ObservableCollection<string> RewardSummary
        {
            get { return _RewardSummary; }
            set { SetProperty(ref _RewardSummary, value); }
        }

        private ObservableCollection<Character> _ParticipatingCharacters;
        public ObservableCollection<Character> ParticipatingCharacters
        {
            get { return _ParticipatingCharacters; }
            set { SetProperty(ref _ParticipatingCharacters, value); }
        }

        private ObservableCollection<Stage> _Stages;
        public ObservableCollection<Stage> Stages
        {
            get { return _Stages; }
            set { SetProperty(ref _Stages, value); }
        }

        public Adventure() : base()
        {
            RewardSummary = new ObservableCollection<string>();
            ParticipatingCharacters = new ObservableCollection<Character>();
            Stages = new ObservableCollection<Stage>();

            Stages.CollectionChanged += stages_CollectionChanged;
        }

        private void stages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
            {
                recreateRewardList();
                RewardSummary.Clear();
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (Encounter element in e.NewItems)
                {
                    element.PropertyChanged += encounterReward_PropertyChanged;
                }
                recreateRewardList();
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                foreach (Encounter element in e.OldItems ?? new List<Stage>())
                {
                    element.PropertyChanged -= encounterReward_PropertyChanged;
                }
                foreach (Encounter element in e.NewItems)
                {
                    element.PropertyChanged += encounterReward_PropertyChanged;
                }
                recreateRewardList();
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (Encounter element in e.OldItems)
                {
                    element.PropertyChanged -= encounterReward_PropertyChanged;
                }
                recreateRewardList();
            }

        }

        private void encounterReward_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "RewardSummary" || e.PropertyName == "AdditionalReward")
            {
                recreateRewardList();
            }
        }

        private void recreateRewardList()
        {
            RewardSummary.Clear();
            foreach (var element in Stages)
            {
                RewardSummary.AddRange(element.RewardSummary);
                RewardSummary.Add(element.AdditionalReward);
            }
        }
    }
}
