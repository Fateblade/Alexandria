using Fateblade.Alexandria.CrossCutting.Entities.DataClasses;
using System;

namespace Fateblade.Alexandria.Logic.Domain.EntitiesManagement.Contract
{
    public interface IMonsterManager
    {
        Monster Get(Guid monsterId);

        void Update(Monster monster);
        void Remove(Monster monster);
        void Add(Monster monster);
    }
}
