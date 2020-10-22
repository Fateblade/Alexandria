using Fateblade.Alexandria.CrossCutting.Gear.DataClasses;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.GearManagement.Contract
{
    public interface IItemManager
    {
        IQueryable<Item> GetAllOwnedByObject(Guid item);
        Item Get(Guid influenceId);

        void Update(Item item);
        void Remove(Item item);
        void Add(Item item);
    }
}
