using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using System;

namespace Fateblade.Alexandria.Logic.Domain.EntitiesManagement.Contract
{
    public interface IFactionManager
    {
        Faction Get(Guid factionId);

        void Update(Faction faction);
        void Remove(Faction faction);
        void Add(Faction faction);
    }
}
