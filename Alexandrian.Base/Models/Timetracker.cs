using System.Collections.ObjectModel;

namespace Alexandrian.Base.Models
{
    public class Timetracker : BaseObject
    {
        private ulong _currentTime;

        private TimeDefinition _Definition;
        public TimeDefinition Definition
        {
            get { return _Definition; }
            set { SetProperty(ref _Definition, value); }
        }

        public TrackableDate CurrentDate
        {
            get { return new TrackableDate(_currentTime); }
        }

        private ObservableCollection<TimetrackEntry> _Entries;
        public ObservableCollection<TimetrackEntry> Entries
        {
            get { return _Entries; }
            set { SetProperty(ref _Entries, value); }
        }
    }
}
