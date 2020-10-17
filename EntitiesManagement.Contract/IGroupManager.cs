using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using System;

namespace Fateblade.Alexandria.Logic.Domain.EntitiesManagement.Contract
{
    public interface IGroupManager
    {
        Group Get(Guid groupId);

        void Update(Group group);
        void Remove(Faction group);
        void Add(Faction group);
    }
}
