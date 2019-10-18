namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public class Deity : NonPlayerCharacter
    {
        // Todo: think about creating aspect class or enum? where? Meta? Entities? Environment?
        public string Aspects { get; set; }
        public override int RelationCategoryID => (int)RelationCategory.Deity;

        //properties - cross link environment
        public int HomeplaneID { get; set; }
    }
}
