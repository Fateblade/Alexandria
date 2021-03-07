using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.Entities.EntitiesManagement
{
    internal class GroupManager : IGroupManager
    {
        private readonly IGenericRepository<Group> _repository;

        public GroupManager(IGenericRepository<Group> repository)
        {
            _repository = repository;
        }

        public IQueryable<Group> GetAll()
        {
            return _repository.Query;
        }

        public Group Get(Guid groupId)
        {
            return _repository.Query.First(t => t.Id == groupId);
        }

        public void Update(Group group)
        {
            _repository.Update(group);
        }

        public void Delete(Faction group)
        {
            _repository.Delete(group);
        }

        public void Add(Faction group)
        {
            _repository.Add(group);
        }
    }
}
