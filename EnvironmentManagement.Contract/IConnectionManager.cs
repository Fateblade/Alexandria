using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.Logic.Domain.EnvironmentManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.EnvironmentManagement.Contract
{
    [MapException(typeof(EnvironmentManagementException))]
    public interface IConnectionManager
    {
        IQueryable<Connection> GetAll();
        IQueryable<Connection> GetAllForSourceObject(Guid sourceObjectId);
        IQueryable<Connection> GetAllForTargetObject(Guid targetObjectId);
        IQueryable<Connection> GetAllForObject(Guid objectId);
        Connection Get(Guid connectionId);

        void Update(Connection connection);
        void Delete(Connection connection);
        void Add(Connection connection);
    }
}
