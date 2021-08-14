using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract.Exceptions;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    [MapException(typeof(MetaManagementException))]
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
