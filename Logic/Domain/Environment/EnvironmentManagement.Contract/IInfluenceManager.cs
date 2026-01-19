using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Environment.EnvironmentManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Environment.EnvironmentManagement.Contract
{
    [MapException(typeof(EnvironmentManagementException))]
    public interface IInfluenceManager
    {
        IQueryable<Influence> GetAll();
        IQueryable<Influence> GetAllForInfluencedObject(Guid objectId);
        IQueryable<Influence> GetAllInfluencedByObject(Guid objectId);
        IQueryable<Influence> GetAllForObject(Guid objectId);
        Influence Get(Guid influenceId);

        void Update(Influence influence);
        void Delete(Influence influence);
        void Add(Influence influence);
    }
}
