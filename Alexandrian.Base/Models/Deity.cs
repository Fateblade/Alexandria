namespace Alexandrian.Base.Models
{
    public class Deity : NonPlayerCharacter
    {
        private string _Aspects;
        public string Aspects
        {
            get { return _Aspects; }
            set { SetProperty(ref _Aspects, value); }
        }


        private Location _Homeplane;
        public Location Homeplane
        {
            get { return _Homeplane; }
            set { SetProperty(ref _Homeplane, value); }
        }
    }
}
