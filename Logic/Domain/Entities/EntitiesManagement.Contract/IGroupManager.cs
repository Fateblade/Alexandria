using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract
{
    [MapException(typeof(EntityManagementExceptionException))]
    public interface IGroupManager
    {
        IQueryable<Group> GetAll();
        Group Get(Guid groupId);

        void Update(Group group);
        void Delete(Faction group);
        void Add(Faction group);
    }
}
