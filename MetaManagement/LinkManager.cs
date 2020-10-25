using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement
{
    internal class LinkManager : ILinkManager
    {
        private readonly IGenericRepository<Link> _repository;

        public LinkManager(IGenericRepository<Link> repository)
        {
            _repository = repository;
        }
        public IQueryable<Link> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Link> GetAllAssociatedWith(Guid objectId)
        {
            return _repository.Query.Where(t => t.AssociatedObject == objectId);
        }

        public Link Get(Guid linkId)
        {
            return _repository.Query.First(t => t.Id == linkId);
        }

        public void Update(Link link)
        {
            _repository.Update(link);
        }

        public void Delete(Link link)
        {
            _repository.Delete(link);
        }

        public void Add(Link link)
        {
            _repository.Add(link);
        }
    }
}
