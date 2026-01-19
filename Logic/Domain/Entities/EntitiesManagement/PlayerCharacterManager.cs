using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement
{
    internal class PlayerCharacterManager : IPlayerCharacterManager
    {
        private readonly IGenericRepository<PlayerCharacter> _repository;



        public PlayerCharacterManager(IGenericRepository<PlayerCharacter> repository)
        {
            _repository = repository;
        }



        public void Add(PlayerCharacter character)
        {
            _repository.Add(character);
        }

        public PlayerCharacter Get(Guid characterId)
        {
            return _repository.Query.First(t => t.Id == characterId);
        }

        public IQueryable<PlayerCharacter> GetAll()
        {
            return _repository.Query;
        }

        public void Delete(PlayerCharacter character)
        {
            _repository.Delete(character);
        }

        public void Update(PlayerCharacter character)
        {
            _repository.Update(character);
        }
    }
}
