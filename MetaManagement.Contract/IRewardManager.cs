using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract
{
    public interface IRewardManager
    {
        IQueryable<Reward> GetAll();
        IQueryable<Reward> GetRewardsOfAdventure(Guid adventureId);
        IQueryable<Reward> GetRewardsOfSession(Guid sessionId);
        IQueryable<Reward> GetRewardsOfEncounter(Guid rewardId);
        Reward Get(Guid rewardId);

        void Update(Reward reward);
        void Remove(Reward reward);
        void Add(Reward reward);
    }
}
