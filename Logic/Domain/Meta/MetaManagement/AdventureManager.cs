using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement
{
    internal class AdventureManager : IAdventureManager
    {
        private readonly IGenericRepository<Adventure> _repository;
        private readonly ISessionManager _sessionManager;



        public AdventureManager(IGenericRepository<Adventure> repository, ISessionManager sessionManager)
        {
            _repository = repository;
            _sessionManager = sessionManager;
        }



        public IQueryable<Adventure> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Adventure> GetAdventuresOfSession(Guid sessionId)
        {
            Session session = _sessionManager.Get(sessionId);
            return _repository.Query.Where(t =>session.PlayedAdventureIds.Contains(t.Id));
        }

        public Adventure Get(Guid adventureId)
        {
            return _repository.Query.First(t => t.Id == adventureId);
        }

        public void Update(Adventure adventure)
        {
            _repository.Update(adventure);
        }

        public void Delete(Adventure adventure)
        {
            _repository.Delete(adventure);
        }

        public void Add(Adventure adventure)
        {
            _repository.Add(adventure);
        }
    }
}
