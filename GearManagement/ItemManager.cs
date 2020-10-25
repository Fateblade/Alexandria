using Fateblade.Alexandria.CrossCutting.Gear.DataClasses;
using Fateblade.Alexandria.Logic.Domain.GearManagement.Contract;
using Fateblade.Components.Data.GenericDataStoring.Contract;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.GearManagement
{
    internal class ItemManager : IItemManager
    {
        private readonly IGenericRepository<Item> _repository;



        public ItemManager(IGenericRepository<Item> repository)
        {
            _repository = repository;
        }



        public IQueryable<Item> GetAll()
        {
            return _repository.Query;
        }

        public IQueryable<Item> GetAllOwnedByObject(Guid objectId)
        {
            return _repository.Query.Where(t=>t.OwningEntity == objectId);
        }

        public Item Get(Guid itemId)
        {
            return _repository.Query.First(t => t.Id == itemId);
        }

        public void Update(Item item)
        {
            _repository.Update(item);
        }

        public void Delete(Item item)
        {
            _repository.Delete(item);
        }

        public void Add(Item item)
        {
            _repository.Add(item);
        }
    }
}
