using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement
{
    internal class TodoManager : ITodoManager
    {
        private readonly IGenericRepository<Todo> _repository;



        public TodoManager(IGenericRepository<Todo> repository)
        {
            _repository = repository;
        }



        public IQueryable<Todo> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Todo> GetTextInfosAssociatedWithObject(Guid objectId)
        {
            return _repository.Query.Where(t => t.AssociatedObjectId == objectId);
        }

        public Todo Get(Guid todoId)
        {
            return _repository.Query.First(t => t.Id == todoId);
        }

        public void Update(Todo todo)
        {
            _repository.Update(todo);
        }

        public void Delete(Todo todo)
        {
            _repository.Delete(todo);
        }

        public void Add(Todo todo)
        {
            _repository.Add(todo);
        }
    }
}
