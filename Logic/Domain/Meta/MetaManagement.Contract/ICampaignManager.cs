using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
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
