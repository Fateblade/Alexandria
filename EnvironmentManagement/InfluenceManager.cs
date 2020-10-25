using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using Fateblade.Alexandria.Logic.Domain.EnvironmentManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.EnvironmentManagement
{
    internal class InfluenceManager : IInfluenceManager
    {
        private readonly IGenericRepository<Influence> _repository;



        public InfluenceManager(IGenericRepository<Influence> repository)
        {
            _repository = repository;
        }



        public IQueryable<Influence> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Influence> GetAllForInfluencedObject(Guid objectId)
        {
            return _repository.Query.Where(t => t.InfluencedObjectId == objectId);
        }

        public IQueryable<Influence> GetAllInfluencedByObject(Guid objectId)
        {
            return _repository.Query.Where(t => t.InfluencingObjectIds.Contains(objectId));
        }

        public IQueryable<Influence> GetAllForObject(Guid objectId)
        {
            return _repository.Query.Where(
                t =>
                t.InfluencedObjectId == objectId 
                || t.InfluencingObjectIds.Contains(objectId));
        }

        public Influence Get(Guid influenceId)
        {
            return _repository.Query.First(t => t.Id == influenceId);
        }

        public void Update(Influence influence)
        {
            _repository.Update(influence);
        }

        public void Delete(Influence influence)
        {
            _repository.Delete(influence);
        }

        public void Add(Influence influence)
        {
            _repository.Add(influence);
        }
    }
}
