using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.EnvironmentManagement.Contract
{
    public interface ILocationManager
    {
        IQueryable<Location> GetAll();
        IQueryable<Location> GetSubLocationsOf(Guid locationId);
        Location Get(Guid locationId);

        void Update(Location location);
        void Remove(Location location);
        void Add(Location location);
    }
}
