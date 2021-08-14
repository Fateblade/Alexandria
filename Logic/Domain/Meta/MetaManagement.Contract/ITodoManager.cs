using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
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
