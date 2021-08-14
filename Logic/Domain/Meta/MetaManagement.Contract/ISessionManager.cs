using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    public interface ISessionManager
    {
        IQueryable<Session> GetAll();
        Session Get(Guid sessionId);

        void Update(Session session);
        void Delete(Session session);
        void Add(Session session);
    }
}
