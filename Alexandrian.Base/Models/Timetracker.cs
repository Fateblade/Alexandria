using System.Collections.ObjectModel;

namespace Alexandrian.Base.Models
{
    public class Timetracker : BaseObject
    {
        private TimeDefinition _Definition;
        public TimeDefinition Definition
        {
            get { return _Definition; }
            set { SetProperty(ref _Definition, value); }
        }

        private TrackableDate _CurrentTime;
        public TrackableDate CurrentTime
        {
            get { return _CurrentTime; }
            set { SetProperty(ref _CurrentTime, value); }
        }

        private ObservableCollection<TimetrackEntry> _Entries;
        public ObservableCollection<TimetrackEntry> Entries
        {
            get { return _Entries; }
            set { SetProperty(ref _Entries, value); }
        }
    }
}
