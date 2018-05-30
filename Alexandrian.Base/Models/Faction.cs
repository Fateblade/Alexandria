using Alexandrian.Base.Interfaces;

namespace Alexandrian.Base.Models
{
    public class Faction : Group
    {
        private string _Motto;
        public string Motto
        {
            get { return _Motto; }
            set { SetProperty(ref _Motto, value); }
        }

        private string _Goals;
        public string Goals
        {
            get { return _Goals; }
            set { SetProperty(ref _Goals, value); }
        }

        private string _Beliefs;
        public string Beliefs
        {
            get { return _Beliefs; }
            set { SetProperty(ref _Beliefs, value); }
        }

        public new RelationCategory RelationCategory => RelationCategory.Faction;
    }
}
