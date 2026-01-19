using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement
{
    internal class MonsterManager : IMonsterManager
    {
        private readonly IGenericRepository<Monster> _repository;

        public MonsterManager(IGenericRepository<Monster> repository)
        {
            _repository = repository;
        }

        public IQueryable<Monster> GetAll()
        {
            return _repository.Query;
        }

        public Monster Get(Guid monsterId)
        {
            return _repository.Query.First(t => t.Id == monsterId);
        }

        public void Update(Monster monster)
        {
            _repository.Update(monster);
        }

        public void Delete(Monster monster)
        {
            _repository.Delete(monster);
        }

        public void Add(Monster monster)
        {
            _repository.Add(monster);
        }
    }
}
