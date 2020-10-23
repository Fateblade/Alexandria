using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.EnvironmentManagement.Contract
{
    public interface IInfluenceManager
    {
        IQueryable<Influence> GetAll();
        IQueryable<Influence> GetAllForInfluencedObject(Guid objectId);
        IQueryable<Influence> GetAllInfluencedByObject(Guid objectId);
        IQueryable<Influence> GetAllForObject(Guid objectId);
        Influence Get(Guid influenceId);

        void Update(Influence influence);
        void Remove(Influence influence);
        void Add(Influence influence);
    }
}
