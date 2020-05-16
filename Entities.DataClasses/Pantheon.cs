using System.Collections.ObjectModel;

namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public class Pantheon : Group
    {
        public ObservableCollection<Deity> Deities;
        public override int RelationCategoryID => (int)RelationCategory.Pantheon;
    }
}
