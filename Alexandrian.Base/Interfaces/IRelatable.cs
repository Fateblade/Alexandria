using Alexandrian.Base.Models;
using System;

namespace Alexandrian.Base.Interfaces
{
    public enum RelationCategory { PC, NPC, Deity, Faction, Monster, Item, Group, Other }
    public interface IRelatable
    {
        Guid ID { get; }
        string Name { get; }
        RelationCategory RelationCategory { get; }
    }
}
