using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement
{
    internal class CampaignManager : ICampaignManager
    {
        private readonly IGenericRepository<Campaign> _repository;



        public CampaignManager(IGenericRepository<Campaign> repository)
        {
            _repository = repository;
        }



        public IQueryable<Campaign> GetAll()
        {
            return _repository.Query;
        }

        public Campaign Get(Guid campaignId)
        {
            return _repository.Query.First(t => t.Id == campaignId);
        }

        public void Update(Campaign campaign)
        {
            _repository.Update(campaign);
        }

        public void Delete(Campaign campaign)
        {
            _repository.Delete(campaign);
        }

        public void Add(Campaign campaign)
        {
            _repository.Add(campaign);
        }
    }
}
