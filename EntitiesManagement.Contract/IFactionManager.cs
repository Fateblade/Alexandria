using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.EntitiesManagement.Contract
{
    public interface IFactionManager
    {
        IQueryable<Faction> GetAllOfWorld(Guid worldId);
        Faction Get(Guid factionId);

        void Update(Faction faction);
        void Remove(Faction faction);
        void Add(Faction faction);
    }
}
