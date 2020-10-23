using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.EntitiesManagement.Contract
{
    public interface IPantheonManager
    {
        IQueryable<Pantheon> GetAll();
        IQueryable<Pantheon> GetAllOfWorld(Guid worldId);
        IQueryable<Pantheon> GetPantheonsContainingDeity(Guid deityId);
        Pantheon Get(Guid pantheonId);

        void Update(Pantheon pantheon);
        void Remove(Pantheon pantheon);
        void Add(Pantheon pantheon);
    }
}
