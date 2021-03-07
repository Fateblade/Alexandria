namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public class NonPlayerCharacter : Character
    {
        public override int RelationCategoryId => (int)RelationCategory.NPC;
    }
}
