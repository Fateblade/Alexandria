using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.EntitiesManagement.Contract
{
    public interface IDeityManager
    {
        IQueryable<Deity> GetAllDeitiesOfPlane(Guid homeplaneId);
        IQueryable<Deity> GetAllDeitiesOfPantheon(Guid pantheon);
        Deity Get(Guid deityId);

        void Update(Deity deity);
        void Remove(Deity deity);
        void Add(Deity deity);
    }
}
