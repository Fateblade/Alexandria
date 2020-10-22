using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.EntitiesManagement.Contract
{
    public interface IPlayerCharacterManager
    {
        IQueryable<NonPlayerCharacter> GetAllOfWorld(Guid worldId);
        PlayerCharacter Get(Guid characterId);

        void Update(PlayerCharacter character);
        void Remove(PlayerCharacter character);
        void Add(PlayerCharacter character);
    }
}
