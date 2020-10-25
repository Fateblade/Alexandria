using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement
{
    internal class NoteManager : INoteManager
    {
        private readonly IGenericRepository<Note> _repository;



        public NoteManager(IGenericRepository<Note> repository)
        {
            _repository = repository;
        }



        public IQueryable<Note> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Note> GetAllAssociatedWith(Guid objectId)
        {
            return _repository.Query.Where(t => t.AssociatedObject == objectId);
        }

        public Note Get(Guid noteId)
        {
            return _repository.Query.First(t => t.Id == noteId);
        }

        public void Update(Note note)
        {
            _repository.Update(note);
        }

        public void Delete(Note note)
        {
            _repository.Delete(note);
        }

        public void Add(Note note)
        {
            _repository.Add(note);
        }
    }
}
