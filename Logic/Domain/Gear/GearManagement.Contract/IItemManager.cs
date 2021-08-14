using System;
using System.Linq;
using Fateblade.Alexandria.CrossCutting.Gear.DataClasses;

namespace Fateblade.Alexandria.Logic.Domain.Gear.GearManagement.Contract
{
    public interface IItemManager
    {
        IQueryable<Item> GetAll();
        IQueryable<Item> GetAllOwnedByObject(Guid itemId);
        Item Get(Guid influenceId);

        void Update(Item item);
        void Delete(Item item);
        void Add(Item item);
    }
}
