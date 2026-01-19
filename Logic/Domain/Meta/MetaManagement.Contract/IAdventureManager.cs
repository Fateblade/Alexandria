using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract.Exceptions;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    [MapException(typeof(MetaManagementException))]
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
