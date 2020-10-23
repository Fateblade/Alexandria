using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.EnvironmentManagement.Contract
{
    public interface IWorldManager
    {
        IQueryable<World> GetAll();
        World Get(Guid worldId);

        void Update(World world);
        void Remove(World world);
        void Add(World world);
    }
}
