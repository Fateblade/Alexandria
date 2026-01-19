using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract
{
    [MapException(typeof(EntityManagementExceptionException))]
    public interface IDeityManager
    {
        IQueryable<Deity> GetAll();
        IQueryable<Deity> GetAllDeitiesOfPantheon(Guid pantheonId);
        Deity Get(Guid deityId);

        void Update(Deity deity);
        void Delete(Deity deity);
        void Add(Deity deity);
    }
}
