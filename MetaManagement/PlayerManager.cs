using Fateblade.Alexandria.CrossCutting.Meta.DataClasses;
using Fateblade.Alexandria.Logic.Domain.MetaManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.MetaManagement
{
    internal class PlayerManager : IPlayerManager
    {
        private readonly IGenericRepository<Player> _repository;



        public PlayerManager(IGenericRepository<Player> repository)
        {
            _repository = repository;
        }



        public IQueryable<Player> GetAll()
        {
            return _repository.Query;
        }

        public Player Get(Guid playerId)
        {
            return _repository.Query.First(t => t.Id == playerId);
        }

        public void Update(Player player)
        {
            _repository.Update(player);
        }

        public void Delete(Player player)
        {
            _repository.Delete(player);
        }

        public void Add(Player player)
        {
            _repository.Add(player);
        }
    }
}
