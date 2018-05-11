using Alexandrian.Base.Interfaces;

namespace Alexandrian.Base.Models
{
    public class Relation : BaseObject
    {
        private IRelatable _Source;
        public IRelatable Source
        {
            get { return _Source; }
            set { SetProperty(ref _Source, value); }
        }

        private IRelatable _Target;
        public IRelatable Target
        {
            get { return _Target; }
            set { SetProperty(ref _Target, value); }
        }

        private string _Reason;
        public string Reason
        {
            get { return _Reason; }
            set { SetProperty(ref _Reason, value); }
        }

        private string _Summary;
        public string Summary
        {
            get { return _Summary; }
            set { SetProperty(ref _Summary, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }
    }
}
