using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract
{
    public interface ICampaignManager
    {
        IQueryable<Campaign> GetAll();
        Campaign Get(Guid campaignId);

        void Update(Campaign campaign);
        void Delete(Campaign campaign);
        void Add(Campaign campaign);
    }
}
