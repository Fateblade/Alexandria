using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    [MapException(typeof(MetaManagementException))]
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
