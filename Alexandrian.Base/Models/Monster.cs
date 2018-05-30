using Alexandrian.Base.Interfaces;
using System.Collections.ObjectModel;

namespace Alexandrian.Base.Models
{
    public class Monster : BaseObject, IRelatable, ISummarizable
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

        public RelationCategory RelationCategory { get; } = RelationCategory.Monster;

        private string _Statistics;
        public string Statistics
        {
            get { return _Statistics; }
            set { SetProperty(ref _Statistics, value); }
        }

        private string _Type;
        public string Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        private string _Summary;
        public string Summary
        {
            get { return _Summary; }
            set { SetProperty(ref _Summary, value); }
        }

        private ObservableCollection<Item> _Items;
        public ObservableCollection<Item> Items
        {
            get { return _Items; }
            set { SetProperty(ref _Items, value); }
        }
    }
}
