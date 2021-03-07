using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement
{
    internal class RelationManager : IRelationManager
    {
        private readonly IGenericRepository<Relation> _repository;



        public RelationManager(IGenericRepository<Relation> repository)
        {
            _repository = repository;
        }



        public void Add(Relation relation)
        {
            _repository.Add(relation);
        }

        public Relation Get(Guid relationId)
        {
            return _repository.Query.First(t => t.Id == relationId);
        }

        public IQueryable<Relation> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Relation> GetAllForEntity(Guid entityId)
        {
            return _repository.Query.Where(t => t.SourceId == entityId || t.TargetId == entityId);
        }

        public IQueryable<Relation> GetAllForSourceEntity(Guid sourceEntityId)
        {
            return _repository.Query.Where(t => t.SourceId == sourceEntityId);
        }

        public IQueryable<Relation> GetAllForTargetEntity(Guid targetEntityId)
        {
            return _repository.Query.Where(t => t.TargetId == targetEntityId);
        }

        public void Delete(Relation relation)
        {
            _repository.Delete(relation);
        }

        public void Update(Relation relation)
        {
            _repository.Update(relation);
        }
    }
}
