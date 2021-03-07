using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract
{
    [MapException(typeof(EntityManagementExceptionException))]
    public interface IPlayerCharacterManager
    {
        IQueryable<PlayerCharacter> GetAll();
        PlayerCharacter Get(Guid characterId);

        void Update(PlayerCharacter character);
        void Delete(PlayerCharacter character);
        void Add(PlayerCharacter character);
    }
}
