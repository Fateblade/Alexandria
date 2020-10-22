using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.EntitiesManagement.Contract
{
    public interface INonPlayerCharacterManager
    {
        IQueryable<NonPlayerCharacter> GetAllOfWorld(Guid worldId);
        NonPlayerCharacter Get(Guid npcId);

        void Update(NonPlayerCharacter npc);
        void Remove(NonPlayerCharacter npc);
        void Add(NonPlayerCharacter npc);
    }
}
