using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract
{
    public interface ISessionManager
    {
        IQueryable<Session> GetAll();
        Session Get(Guid sessionId);

        void Update(Session session);
        void Remove(Session session);
        void Add(Session session);
    }
}
