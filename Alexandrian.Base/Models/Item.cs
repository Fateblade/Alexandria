using Alexandrian.Base.Interfaces;

namespace Alexandrian.Base.Models
{
    public class Item : BaseObject, IRelatable
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

        private string _Type;
        public string Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        private string _Statistics;
        public string Statistics
        {
            get { return _Statistics; }
            set { SetProperty(ref _Statistics, value); }
        }

        public RelationCategory RelationCategory { get; } = RelationCategory.Item;
    }
}
