using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract
{
    [MapException(typeof(EntityManagementExceptionException))]
    public interface IMonsterManager
    {
        IQueryable<Monster> GetAll();
        Monster Get(Guid monsterId);

        void Update(Monster monster);
        void Delete(Monster monster);
        void Add(Monster monster);
    }
}
