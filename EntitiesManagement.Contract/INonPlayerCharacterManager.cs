using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract
{
    [MapException(typeof(EntityManagementExceptionException))]
    public interface INonPlayerCharacterManager
    {
        IQueryable<NonPlayerCharacter> GetAll();
        NonPlayerCharacter Get(Guid npcId);

        void Update(NonPlayerCharacter npc);
        void Delete(NonPlayerCharacter npc);
        void Add(NonPlayerCharacter npc);
    }
}
