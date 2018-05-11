namespace Alexandrian.Base.Models
{
    public class Faction : BaseObject
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

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

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }
    }
}
