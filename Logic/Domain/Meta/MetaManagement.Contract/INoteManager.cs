using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
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
