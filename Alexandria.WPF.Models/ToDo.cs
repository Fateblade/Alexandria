namespace Alexandria.WPF.Models
{
    public enum TodoType { Adventure, Campaign, Character, Connection, Deity, Encounter, Faction, Group, Influence, Item, Link, Location, Monster, NonPlayerCharacter, Relation, Session, Stage, World}

    public class ToDo
    {
        public TodoType Type { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
    }
}
