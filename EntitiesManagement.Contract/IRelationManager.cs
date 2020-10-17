using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.EntitiesManagement.Contract
{
    public interface IRelationManager
    {
        IQueryable<Relation> GetAllForSourceEntity(Guid sourceEntityId);
        IQueryable<Relation> GetAllForTargetEntity(Guid targetEntityId);
        Relation Get(Guid relationId);


        void Update(Relation relation);
        void Remove(Relation relation);
        void Add(Relation relation);
    }
}
