using System.Collections.ObjectModel;
using System.Linq;

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
        }

        private ObservableCollection<TimetrackEntry> _Entries;
        public ObservableCollection<TimetrackEntry> Entries
        {
            get { return _Entries; }
            set { SetProperty(ref _Entries, value); }
        }

        public string GetDescription(TrackableDate date, TimeFormat format=null)
        {
            string retVal = string.Empty;

            if(format == null) { format = Definition.DefaultFormat; }

            var rootElement = Definition.Units.First(t => t.RelationTarget == null);
            
            //build tree 
            

            return retVal;
        }

        
    }
}
