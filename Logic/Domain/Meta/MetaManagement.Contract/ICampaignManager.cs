using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    [MapException(typeof(MetaManagementException))]
    public interface ICampaignManager
    {
        IQueryable<Campaign> GetAll();
        Campaign Get(Guid campaignId);

        void Update(Campaign campaign);
        void Delete(Campaign campaign);
        void Add(Campaign campaign);
    }
}
