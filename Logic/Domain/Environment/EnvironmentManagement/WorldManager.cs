using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Environment.EnvironmentManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;

namespace Fateblade.Alexandria.Logic.Domain.Environment.EnvironmentManagement
{
    internal class WorldManager :  IWorldManager
    {
        private readonly IGenericRepository<World> _repository;



        public WorldManager(IGenericRepository<World> repository)
        {
            _repository = repository;
        }



        public IQueryable<World> GetAll()
        {
            return _repository.Query;
        }

        public World Get(Guid worldId)
        {
            return _repository.Query.First(t => t.Id == worldId);
        }

        public void Update(World world)
        {
            _repository.Update(world);
        }

        public void Delete(World world)
        {
            _repository.Delete(world);
        }

        public void Add(World world)
        {
            _repository.Add(world);
        }
    }
}
