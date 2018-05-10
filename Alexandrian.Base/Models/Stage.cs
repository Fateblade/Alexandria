using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Alexandrian.Base.Models
{
    public class Stage : BaseObject
    {
        private string _Summary;
        public string Summary
        {
            get { return _Summary; }
            set { SetProperty(ref _Summary, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
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

        private ObservableCollection<Encounter> _Encounters;
        public ObservableCollection<Encounter> Encounters
        {
            get { return _Encounters; }
            set { SetProperty(ref _Encounters, value); }
        }

        public Stage() : base()
        {
            _Encounters = new ObservableCollection<Encounter>();
            _RewardSummary = new ObservableCollection<string>();

            _Encounters.CollectionChanged += encounters_CollectionChanged;
        }

        private void encounters_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
            {
                recreateRewardList();
                RewardSummary.Clear();
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach(Encounter element in e.NewItems)
                {
                    element.PropertyChanged += encounterReward_PropertyChanged;
                }
                recreateRewardList();
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                foreach (Encounter element in e.OldItems ?? new List<Encounter>())
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
            if(e.PropertyName == "Reward")
            {
                recreateRewardList();
            }
        }

        private void recreateRewardList()
        {
            RewardSummary.Clear();
            foreach (var element in Encounters)
            {
                RewardSummary.Add(element.Reward);
            }
        }
    }

}
