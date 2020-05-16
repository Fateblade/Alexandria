using System.Collections.Generic;
using System.Linq;

namespace Fateblade.Alexandria.CrossCutting.Environment.DataClasses
{
    public class Timetracker
    {
        public TimeDefinition Definition { get; set; }

        public TrackableDateStamp CurrentTime { get; set; }

        public List<TimetrackerEntry> Entries { get; set; }

        public string GetDescription(TrackableDateStamp date, TimeFormat format = null)
        {
            string retVal = string.Empty;

            if (format == null) { format = Definition.DefaultFormat; }

            var rootElement = Definition.Units.First(t => t.RelationTarget == null);

            //build tree 


            return retVal;
        }

    }
}
