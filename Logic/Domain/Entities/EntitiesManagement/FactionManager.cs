using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement
{
    internal class FactionManager : IFactionManager
    {
        private readonly IGenericRepository<Faction> _repository;



        public FactionManager(IGenericRepository<Faction> repository)
        {
            _repository = repository;
        }



        public IQueryable<Faction> GetAll()
        {
            return _repository.Query;
        }

        public Faction Get(Guid factionId)
        {
            return _repository.Query.First(t => t.Id == factionId);
        }

        public void Update(Faction faction)
        {
            _repository.Update(faction);
        }

        public void Delete(Faction faction)
        {
            _repository.Delete(faction);
        }

        public void Add(Faction faction)
        {
            _repository.Add(faction);
        }
    }
}
