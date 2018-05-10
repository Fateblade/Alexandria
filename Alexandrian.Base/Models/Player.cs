using System.Collections.Generic;

namespace Alexandrian.Base.Models
{
    public class Player : BaseObject
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        private List<TextInfo> _NoGos;
        public List<TextInfo> NoGos
        {
            get { return _NoGos; }
            set { SetProperty(ref _NoGos, value); }
        }

        private string _GenderPronoun;
        public string GenderPronoun
        {
            get { return _GenderPronoun; }
            set { SetProperty(ref _GenderPronoun, value); }
        }

        private List<TextInfo> _Likes;
        public List<TextInfo> Likes
        {
            get { return _Likes; }
            set { SetProperty(ref _Likes, value); }
        }

        private List<TextInfo> _Dislikes;
        public List<TextInfo> Dislikes
        {
            get { return _Dislikes; }
            set { SetProperty(ref _Dislikes, value); }
        }
    }
}
