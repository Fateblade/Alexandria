using System.Collections.ObjectModel;

namespace Alexandrian.Base.Models
{
    public class Pantheon : BaseObject
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

        private ObservableCollection<Deity> _Deities;
        public ObservableCollection<Deity> Deities
        {
            get { return _Deities; }
            set { SetProperty(ref _Deities, value); }
        }
    }
}
