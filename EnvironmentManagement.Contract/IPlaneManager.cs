using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.EnvironmentManagement.Contract
{
    public interface IPlaneManager
    {
        IQueryable<Plane> GetAllPlanesOfWorld(Guid worldId);
        Plane Get(Guid planeId);

        void Update(Plane plane);
        void Remove(Plane plane);
        void Add(Plane plane);
    }
}
