using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement
{
    internal class RewardManager : IRewardManager
    {
        private readonly IGenericRepository<Reward> _repository;
        private readonly IAdventureManager _adventureManager;
        private readonly IEncounterManager _encounterManager;


        public RewardManager(IGenericRepository<Reward> repository, IAdventureManager adventureManager, IEncounterManager encounterManager)
        {
            _repository = repository;
            _adventureManager = adventureManager;
            _encounterManager = encounterManager;
        }



        public IQueryable<Reward> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Reward> GetRewardsOfAdventure(Guid adventureId)
        {
            Adventure adventure = _adventureManager.Get(adventureId);

            return _repository.Query.Where(t => adventure.RewardIds.Contains(t.Id));
        }

        public IQueryable<Reward> GetRewardsOfEncounter(Guid encounterId)
        {
            Encounter encounter = _encounterManager.Get(encounterId);

            return _repository.Query.Where(t => encounter.RewardIds.Contains(t.Id));
        }

        public Reward Get(Guid rewardId)
        {
            return _repository.Query.First(t => t.Id == rewardId);
        }

        public void Update(Reward reward)
        {
            _repository.Update(reward);
        }

        public void Delete(Reward reward)
        {
            _repository.Delete(reward);
        }

        public void Add(Reward reward)
        {
            _repository.Add(reward);
        }
    }
}
