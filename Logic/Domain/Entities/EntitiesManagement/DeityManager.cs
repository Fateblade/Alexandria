using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement
{
    internal class DeityManager : IDeityManager
    {
        private readonly IGenericRepository<Deity> _repository;
        private readonly IGenericRepository<Pantheon> _pantheonRepository;



        public DeityManager(IGenericRepository<Deity> repository, IGenericRepository<Pantheon> pantheonRepository)
        {
            _repository = repository;
            _pantheonRepository = pantheonRepository;
        }



        public IQueryable<Deity> GetAll()
        {
            return _repository.Query;
        }
        
        public IQueryable<Deity> GetAllDeitiesOfPantheon(Guid pantheonId)
        {
            Pantheon pantheon = _pantheonRepository.Query.First(t => t.Id == pantheonId);

            return _repository.Query.Where(t => pantheon.DeityIds.Contains(t.Id));
        }

        public Deity Get(Guid deityId)
        {
            return _repository.Query.First(t => t.Id == deityId);
        }

        public void Update(Deity deity)
        {
            _repository.Update(deity);
        }

        public void Delete(Deity deity)
        {
            _repository.Delete(deity);
        }

        public void Add(Deity deity)
        {
            _repository.Add(deity);
        }
    }
}
