using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using System;

namespace Fateblade.Alexandria.Logic.Domain.EntitiesManagement.Contract
{
    public interface INonPlayerCharacterManager
    {
        NonPlayerCharacter Get(Guid npcId);

        void Update(NonPlayerCharacter npc);
        void Remove(NonPlayerCharacter npc);
        void Add(NonPlayerCharacter npc);
    }
}
