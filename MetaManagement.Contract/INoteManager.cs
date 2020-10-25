using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract
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
