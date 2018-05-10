using System.Collections.ObjectModel;

namespace Alexandrian.Base.Models
{
    public class Campaign : BaseObject
    {
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
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

        private string _Theme;
        public string Theme
        {
            get { return _Theme; }
            set { SetProperty(ref _Theme, value); }
        }

        private ObservableCollection<Session> _Sessions;
        public ObservableCollection<Session> Sessions
        {
            get { return _Sessions; }
            set { SetProperty(ref _Sessions, value); }
        }

        private ObservableCollection<Adventure> _Adventures;
        public ObservableCollection<Adventure> Adventures
        {
            get { return _Adventures; }
            set { SetProperty(ref _Adventures, value); }
        }

        private ObservableCollection<Character> _PlayingCharacters;
        public ObservableCollection<Character> PlayingCharacters
        {
            get { return _PlayingCharacters; }
            set { SetProperty(ref _PlayingCharacters, value); }
        }

        private World _WorldPlayedIn;
        public World WorldPlayedIn
        {
            get { return _WorldPlayedIn; }
            set { SetProperty(ref _WorldPlayedIn, value); }
        }
    }
}
