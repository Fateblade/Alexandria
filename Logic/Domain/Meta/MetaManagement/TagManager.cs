using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement
{
    internal class TagManager : ITagManager
    {
        private readonly IGenericRepository<Tag> _repository;



        public TagManager(IGenericRepository<Tag> repository)
        {
            _repository = repository;
        }



        public IQueryable<Tag> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Tag> GetTagsAssociatedWithObject(Guid objectId)
        {
            return _repository.Query.Where(t => t.AssociatedObject == objectId);
        }

        public Tag Get(Guid tagId)
        {
            return _repository.Query.First(t => t.Id == tagId);
        }

        public void Update(Tag tag)
        {
            _repository.Update(tag);
        }

        public void Delete(Tag tag)
        {
            _repository.Delete(tag);
        }

        public void Add(Tag tag)
        {
            _repository.Add(tag);
        }
    }
}
