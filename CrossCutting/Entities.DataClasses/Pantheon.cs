using System;
using System.Collections.ObjectModel;

namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public class Pantheon : Group
    {
        public ObservableCollection<Guid> DeityIds;
        public override int RelationCategoryId => (int)RelationCategory.Pantheon;
    }
}
