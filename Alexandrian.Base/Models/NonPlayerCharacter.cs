namespace Alexandrian.Base.Models
{
    public class NonPlayerCharacter : Character
    {
        public NonPlayerCharacter() : base()
        {
            _RelationCategory = Interfaces.RelationCategory.NPC;
        }
    }
}
