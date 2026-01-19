using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;
using Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement
{
    internal class SessionManager : ISessionManager
    {
        private readonly IGenericRepository<Session> _repository;



        public SessionManager(IGenericRepository<Session> repository)
        {
            _repository = repository;
        }



        public IQueryable<Session> GetAll()
        {
            return _repository.Query;
        }

        public Session Get(Guid sessionId)
        {
            return _repository.Query.First(t => t.Id == sessionId);
        }

        public void Update(Session session)
        {
            _repository.Update(session);
        }

        public void Delete(Session session)
        {
            _repository.Delete(session);
        }

        public void Add(Session session)
        {
            _repository.Add(session);
        }
    }
}
