using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract
{
    public interface IPlayerManager
    {
        IQueryable<Player> GetAll();
        Player Get(Guid playerId);

        void Update(Player player);
        void Remove(Player player);
        void Add(Player player);
    }
}
