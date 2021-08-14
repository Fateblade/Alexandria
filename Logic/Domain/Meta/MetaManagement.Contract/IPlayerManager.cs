using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;

namespace Fateblade.Alexandria.Logic.Domain.Meta.MetaManagement.Contract
{
    public interface IPlayerManager
    {
        IQueryable<Player> GetAll();
        Player Get(Guid playerId);

        void Update(Player player);
        void Delete(Player player);
        void Add(Player player);
    }
}
