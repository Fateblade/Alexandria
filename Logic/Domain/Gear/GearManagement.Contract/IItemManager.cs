using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Alexandria.CrossCutting.Gear.DataClasses;
using Fateblade.Alexandria.Logic.Domain.Gear.GearManagement.Contract.Exceptions;
using System;
using System.Linq;

namespace Fateblade.Alexandria.Logic.Domain.Gear.GearManagement.Contract
{
    [MapException(typeof(GearManagementException))]
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
