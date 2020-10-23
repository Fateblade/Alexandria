using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.EntitiesManagement.Contract
{
    public interface IGroupManager
    {
        IQueryable<Group> GetAll();
        IQueryable<Group> GetAllOfWorld(Guid worldId);
        Group Get(Guid groupId);

        void Update(Group group);
        void Remove(Faction group);
        void Add(Faction group);
    }
}
