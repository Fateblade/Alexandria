using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    public interface IRewardManager
    {
        IQueryable<Reward> GetAll();
        IQueryable<Reward> GetRewardsOfAdventure(Guid adventureId);
        IQueryable<Reward> GetRewardsOfEncounter(Guid rewardId);
        Reward Get(Guid rewardId);

        void Update(Reward reward);
        void Delete(Reward reward);
        void Add(Reward reward);
    }
}
