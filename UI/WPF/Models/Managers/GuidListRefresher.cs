using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fateblade.Alexandria.UI.WPF.Models.Managers
{
    internal class GuidListRefresher
    {
        private static GuidListRefresher _instance;
        public static GuidListRefresher Instance => _instance ?? (_instance = new GuidListRefresher());


        private GuidListRefresher() { }


        public void RefreshList(List<Guid> original, IEnumerable<Guid> newList)
        {
            IEnumerable<Guid> guidsToRemove = original.Where(entry => newList.All(updatedEntry => updatedEntry != entry));
            IEnumerable<Guid> guidsToAdd = newList.Where(entry => original.All(oldEntry => entry != oldEntry));

            guidsToRemove.ToList().ForEach(entryToRemove=> original.Remove(entryToRemove));
            guidsToAdd.ToList().ForEach(original.Add);
        }
    }
}
