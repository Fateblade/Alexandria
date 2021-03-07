namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public class Monster : Entity
    {
        public string Type { get; set; }
        public override int RelationCategoryId => (int)RelationCategory.Monster;
    }
}
