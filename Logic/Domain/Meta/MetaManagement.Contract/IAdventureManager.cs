using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{ //Todo: add exception mapping and coco core for entire project
    public interface IAdventureManager
    {
        IQueryable<Adventure> GetAll();
        IQueryable<Adventure> GetAdventuresOfSession(Guid sessionId);
        Adventure Get(Guid adventureId);

        void Update(Adventure adventure);
        void Delete(Adventure adventure);
        void Add(Adventure adventure);
    }
}
