namespace Fateblade.Alexandria.UI.WPF.Models.Meta
{
    class StageModel
    {

        //private void encounters_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
        //    {
        //        recreateRewardList();
        //        RewardSummary.Clear();
        //    }
        //    else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
        //    {
        //        foreach (Encounter element in e.NewItems)
        //        {
        //            element.PropertyChanged += encounterReward_PropertyChanged;
        //        }
        //        recreateRewardList();
        //    }
        //    else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
        //    {
        //        foreach (Encounter element in e.OldItems ?? new List<Encounter>())
        //        {
        //            element.PropertyChanged -= encounterReward_PropertyChanged;
        //        }
        //        foreach (Encounter element in e.NewItems)
        //        {
        //            element.PropertyChanged += encounterReward_PropertyChanged;
        //        }
        //        recreateRewardList();
        //    }
        //    else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
        //    {
        //        foreach (Encounter element in e.OldItems)
        //        {
        //            element.PropertyChanged -= encounterReward_PropertyChanged;
        //        }
        //        recreateRewardList();
        //    }

        //}

        //private void encounterReward_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == "Reward")
        //    {
        //        recreateRewardList();
        //    }
        //}

        //private void recreateRewardList()
        //{
        //    RewardSummary.Clear();
        //    foreach (var element in Encounters)
        //    {
        //        RewardSummary.Add(element.Reward);
        //    }
        //}
    }
}
