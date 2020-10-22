using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using System;

namespace Fateblade.Alexandria.Logic.Domain.EnvironmentManagement.Contract
{
    public interface IWorldManager
    {
        World Get(Guid worldId);

        void Update(World world);
        void Remove(World world);
        void Add(World world);
    }
}
