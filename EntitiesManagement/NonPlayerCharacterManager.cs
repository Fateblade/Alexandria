using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement
{
    internal class NonPlayerCharacterManager : INonPlayerCharacterManager
    {
        private readonly IGenericRepository<NonPlayerCharacter> _repository;



        public NonPlayerCharacterManager(IGenericRepository<NonPlayerCharacter> repository)
        {
            _repository = repository;
        }



        public IQueryable<NonPlayerCharacter> GetAll()
        {
            return _repository.Query;
        }

        public NonPlayerCharacter Get(Guid npcId)
        {
            return _repository.Query.First(t=>t.Id == npcId);
        }

        public void Update(NonPlayerCharacter npc)
        {
            _repository.Update(npc);
        }

        public void Delete(NonPlayerCharacter npc)
        {
            _repository.Delete(npc);
        }

        public void Add(NonPlayerCharacter npc)
        {
            _repository.Add(npc);
        }
    }
}
