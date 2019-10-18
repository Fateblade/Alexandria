using System;

namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public class Faction : Group
    {
        public string Motto;
        public string Goals;
        public string Beliefs;
        public override int RelationCategoryID => (int)RelationCategory.Faction;
    }
}
