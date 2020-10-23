using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.EnvironmentManagement.Contract
{
    public interface IConnectionManager
    {
        IQueryable<Connection> GetAll();
        IQueryable<Connection> GetAllForSourceObject(Guid sourceObjectId);
        IQueryable<Connection> GetAllForTargetObject(Guid targetObjectId);
        IQueryable<Connection> GetAllForObject(Guid objectId);
        Connection Get(Guid connectionId);

        void Update(Connection connection);
        void Remove(Connection connection);
        void Add(Connection connection);
    }
}
