using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract
{
    public interface IAdventureManager
    {
        IQueryable<Adventure> GetAll();
        IQueryable<Adventure> GetAdventuresOfSession(Guid sessionId);
        Adventure Get(Guid adventureId);

        void Update(Adventure adventure);
        void Remove(Adventure adventure);
        void Add(Adventure adventure);
    }
}
