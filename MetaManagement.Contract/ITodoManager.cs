using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract
{
    public interface ITodoManager
    {
        IQueryable<Todo> GetAll();
        IQueryable<Todo> GetTextInfosAssociatedWithObject(Guid objectId);
        Todo Get(Guid todoId);

        void Update(Todo todo);
        void Delete(Todo todo);
        void Add(Todo todo);
    }
}
