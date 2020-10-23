using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.EntitiesManagement.Contract
{
    public interface IMonsterManager
    {
        IQueryable<Monster> GetAll();
        IQueryable<Monster> GetAllOfWorld(Guid worldId);
        Monster Get(Guid monsterId);

        void Update(Monster monster);
        void Remove(Monster monster);
        void Add(Monster monster);
    }
}
