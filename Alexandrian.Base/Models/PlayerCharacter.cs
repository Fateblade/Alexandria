namespace Alexandrian.Base.Models
{
    public class PlayerCharacter : Character
    {
        private Player _ControllingPlayer;
        public Player ControllingPlayer
        {
            get { return _ControllingPlayer; }
            set { SetProperty(ref _ControllingPlayer, value); }
        }

        public PlayerCharacter() : base()
        {
            _RelationCategory = Interfaces.RelationCategory.PC;
        }
    }
}