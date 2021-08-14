using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Environment.EnvironmentManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;

namespace Fateblade.Alexandria.Logic.Domain.Environment.EnvironmentManagement
{
    internal class PlaneManager : IPlaneManager
    {
        private readonly IGenericRepository<Plane> _repository;
        private readonly IWorldManager _worldManager;



        public PlaneManager(IGenericRepository<Plane> repository, IWorldManager worldManager)
        {
            _repository = repository;
            _worldManager = worldManager;
        }



        public IQueryable<Plane> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Plane> GetAllPlanesOfWorld(Guid worldId)
        { 
            World world = _worldManager.Get(worldId);
            return _repository.Query.Where(t => world.PlaneIds.Contains(t.Id));
        }

        public Plane Get(Guid planeId)
        {
            return _repository.Query.First(t => t.Id == planeId);
        }

        public void Update(Plane plane)
        {
            _repository.Update(plane);
        }

        public void Delete(Plane plane)
        {
            _repository.Delete(plane);
        }

        public void Add(Plane plane)
        {
            _repository.Add(plane);
        }
    }
}
