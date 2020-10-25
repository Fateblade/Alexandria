using Fateblade.Alexandria.CrossCutting.Environment.DataClasses;
using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.Logic.Domain.EnvironmentManagement.Contract.Exceptions;

namespace Fateblade.Alexandria.Logic.Domain.EnvironmentManagement.Contract
{
    [MapException(typeof(EnvironmentManagementException))]
    public interface IWorldManager
    {
        IQueryable<World> GetAll();
        World Get(Guid worldId);

        void Update(World world);
        void Delete(World world);
        void Add(World world);
    }
}
