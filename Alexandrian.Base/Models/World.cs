using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexandrian.Base.Models
{
    public class World : BaseObject
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        private string _Summary;
        public string Summary
        {
            get { return _Summary; }
            set { SetProperty(ref _Summary, value); }
        }

        private string _Timeline;
        public string Timeline
        {
            get { return _Timeline; }
            set { SetProperty(ref _Timeline, value); }
        }

        private Timetracker _Tracker;
        public Timetracker Tracker
        {
            get { return _Tracker; }
            set { SetProperty(ref _Tracker, value); }
        }

        private ObservableCollection<Plane> _Planes;
        public ObservableCollection<Plane> Planes
        {
            get { return _Planes; }
            set { SetProperty(ref _Planes, value); }
        }

        private ObservableCollection<Pantheon> _Pantheons;
        public ObservableCollection<Pantheon> Pantheons
        {
            get { return _Pantheons; }
            set { SetProperty(ref _Pantheons, value); }
        }
    }
}
