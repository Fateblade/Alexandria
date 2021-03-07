using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement
{
    internal class PantheonManager : IPantheonManager
    {
        private readonly IGenericRepository<Pantheon> _repository;



        public PantheonManager(IGenericRepository<Pantheon> repository)
        {
            _repository = repository;
        }



        public void Add(Pantheon pantheon)
        {
            _repository.Add(pantheon);
        }

        public Pantheon Get(Guid pantheonId)
        {
            return _repository.Query.First(t => t.Id == pantheonId);
        }

        public IQueryable<Pantheon> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Pantheon> GetPantheonsContainingDeity(Guid deityId)
        {
            return _repository.Query.Where(t => t.DeityIds.Contains(deityId));
        }

        public void Delete(Pantheon pantheon)
        {
            _repository.Delete(pantheon);
        }

        public void Update(Pantheon pantheon)
        {
            _repository .Update(pantheon);
        }
    }
}
