using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using Fateblade.Alexandria.Logic.Domain.EnvironmentManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;

namespace Fateblade.Alexandria.Logic.Domain.EnvironmentManagement
{
    internal class ConnectionManager : IConnectionManager
    {
        private readonly IGenericRepository<Connection> _repository;



        public ConnectionManager(IGenericRepository<Connection> repository)
        {
            _repository = repository;
        }



        public IQueryable<Connection> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Connection> GetAllForSourceObject(Guid sourceObjectId)
        {
            return _repository.Query.Where(t => t.SourceObjectId == sourceObjectId);
        }

        public IQueryable<Connection> GetAllForTargetObject(Guid targetObjectId)
        {
            return _repository.Query.Where(t => t.TargetObjectId == targetObjectId);
        }

        public IQueryable<Connection> GetAllForObject(Guid objectId)
        {
            return _repository.Query.Where(
                t =>
                    t.SourceObjectId == objectId
                    || t.TargetObjectId == objectId);
        }

        public Connection Get(Guid connectionId)
        {
            return _repository.Query.First(t => t.Id == connectionId);
        }

        public void Update(Connection connection)
        {
            _repository.Update(connection);
        }

        public void Delete(Connection connection)
        {
            _repository.Delete(connection);
        }

        public void Add(Connection connection)
        {
            _repository.Add(connection);
        }
    }
}
