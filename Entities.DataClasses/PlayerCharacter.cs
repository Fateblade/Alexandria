namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public class PlayerCharacter : Character
    {
        public int ControllingPlayerID { get; set; }
        public override int RelationCategoryID => (int)RelationCategory.PC;
    }
}