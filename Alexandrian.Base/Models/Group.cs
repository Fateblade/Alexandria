using Alexandrian.Base.Interfaces;

namespace Alexandrian.Base.Models
{
    public class Group : BaseObject, IRelatable
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        private string _Concept;
        public string Concept
        {
            get { return _Concept; }
            set { SetProperty(ref _Concept, value); }
        }

        private string _Backstory;
        public string Backstory
        {
            get { return _Backstory; }
            set { SetProperty(ref _Backstory, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        public RelationCategory RelationCategory => RelationCategory.Group;
    }
}
