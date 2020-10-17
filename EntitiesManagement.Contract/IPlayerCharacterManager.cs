using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using System;

namespace Fateblade.Alexandria.Logic.Domain.EntitiesManagement.Contract
{
    public interface IPlayerCharacterManager
    {
        PlayerCharacter Get(Guid characterId);

        void Update(PlayerCharacter character);
        void Remove(PlayerCharacter character);
        void Add(PlayerCharacter character);
    }
}
