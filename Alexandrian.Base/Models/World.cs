using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

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
            set { SetProperty(ref _Tracker, value, onTrackerChanged); }
        }

        private ObservableCollection<Location> _Planes;
        public ObservableCollection<Location> Planes
        {
            get { return _Planes; }
            set { SetProperty(ref _Planes, value); }
        }

        private ObservableCollection<Group> _Pantheons;
        public ObservableCollection<Group> Pantheons
        {
            get { return _Pantheons; }
            set { SetProperty(ref _Pantheons, value); }
        }

        private ObservableCollection<NonPlayerCharacter> _Npcs;
        public ObservableCollection<NonPlayerCharacter> Npcs
        {
            get { return _Npcs; }
            set { SetProperty(ref _Npcs, value); }
        }

        private ObservableCollection<Monster> _Monsters;
        public ObservableCollection<Monster> Monsters
        {
            get { return _Monsters; }
            set { SetProperty(ref _Monsters, value); }
        }

        private ObservableCollection<Faction> _Factions;
        public ObservableCollection<Faction> Factions
        {
            get { return _Factions; }
            set { SetProperty(ref _Factions, value); }
        }

        private void onTrackerChanged()
        {
            _Tracker.Entries.CollectionChanged += Entries_CollectionChanged;
        }

        private void recreateTimeline()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(TrackableDate.DayName);
            sb.Append(".");
            sb.Append(TrackableDate.MonthName);
            sb.Append(".");
            sb.Append(TrackableDate.YearName);
            sb.Append(" ");
            sb.Append(TrackableDate.HourName);
            sb.Append(":");
            sb.Append(TrackableDate.MinuteName);
            sb.Append(":");
            sb.Append(TrackableDate.SecondName);
            sb.Append("]");
            sb.AppendLine(" Summary");

            foreach (var entry in _Tracker.Entries.OrderBy(t=>t.Date.DatePart))
            {
                sb.Append("[");
                sb.Append(entry.Date.Day);
                sb.Append(".");
                sb.Append(entry.Date.Month);
                sb.Append(".");
                sb.Append(entry.Date.Year);
                sb.Append(" ");
                sb.Append(entry.Date.Hour);
                sb.Append(":");
                sb.Append(entry.Date.Minute);
                sb.Append(":");
                sb.Append(entry.Date.Second);
                sb.Append("]");
                sb.AppendLine(entry.Summary);
            }
            Timeline = sb.ToString();
        }

        private void Entries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(sender != _Tracker?.Entries) { return; }

            recreateTimeline();
        }
    }
}
