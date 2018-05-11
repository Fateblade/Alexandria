namespace Alexandrian.Base.Models
{
    public class Deity : BaseObject
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        private string _Summary;
        public string Summary
        {
            get { return _Summary; }
            set { SetProperty(ref _Summary, value); }
        }

        private string _Aspects;
        public string Aspects
        {
            get { return _Aspects; }
            set { SetProperty(ref _Aspects, value); }
        }
    }
}
