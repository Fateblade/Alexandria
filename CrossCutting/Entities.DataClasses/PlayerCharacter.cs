using System;

namespace Fateblade.Alexandria.CrossCutting.Entities.DataClasses
{
    public class PlayerCharacter : Character
    {
        public Guid ControllingPlayerId { get; set; }
        public override int RelationCategoryId => (int)RelationCategory.PC;
    }
}