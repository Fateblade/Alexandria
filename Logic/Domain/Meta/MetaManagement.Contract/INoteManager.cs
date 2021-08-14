using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    [MapException(typeof(MetaManagementException))]
    public interface INoteManager
    {
        IQueryable<Note> GetAll();
        IQueryable<Note> GetAllAssociatedWith(Guid objectId);
        Note Get(Guid noteId);

        void Update(Note note);
        void Delete(Note note);
        void Add(Note note);
    }
}
