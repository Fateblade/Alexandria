using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Environment.EnvironmentManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;

namespace Fateblade.Alexandria.Logic.Domain.Environment.EnvironmentManagement
{
    internal class LocationManager : ILocationManager
    {
        private readonly IGenericRepository<Location> _repository;



        public LocationManager(IGenericRepository<Location> repository)
        {
            _repository = repository;
        }



        public IQueryable<Location> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Location> GetSubLocationsOf(Guid locationId)
        {
            return _repository.Query.Where(t => t.SubLocationOf == locationId);
        }

        public Location Get(Guid locationId)
        {
            return _repository.Query.First(t => t.Id == locationId);
        }

        public void Update(Location location)
        {
            _repository.Update(location);
        }

        public void Delete(Location location)
        {
            _repository.Delete(location);
        }

        public void Add(Location location)
        {
            _repository.Add(location);
        }
    }
}
