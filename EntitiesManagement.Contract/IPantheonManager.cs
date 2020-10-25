using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract
{
    [MapException(typeof(EntityManagementExceptionException))]
    public interface IPantheonManager
    {
        IQueryable<Pantheon> GetAll();
        IQueryable<Pantheon> GetPantheonsContainingDeity(Guid deityId);
        Pantheon Get(Guid pantheonId);

        void Update(Pantheon pantheon);
        void Delete(Pantheon pantheon);
        void Add(Pantheon pantheon);
    }
}
