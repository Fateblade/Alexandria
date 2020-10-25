using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract
{
    [MapException(typeof(EntityManagementExceptionException))]
    public interface IRelationManager
    {
        IQueryable<Relation> GetAll();
        IQueryable<Relation> GetAllForEntity(Guid entityId);
        IQueryable<Relation> GetAllForSourceEntity(Guid sourceEntityId);
        IQueryable<Relation> GetAllForTargetEntity(Guid targetEntityId);
        Relation Get(Guid relationId);


        void Update(Relation relation);
        void Delete(Relation relation);
        void Add(Relation relation);
    }
}
