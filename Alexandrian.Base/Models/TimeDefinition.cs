namespace Alexandrian.Base.Models
{
    public class TimeDefinition : BaseObject
    {
        public string SecondName { get; private set; }
        public ushort SecondMax { get; private set; }

        public string MinuteName { get; private set; }
        public ushort MinuteMax { get; private set; }

        public string HourName { get; private set; } 
        public ushort HourMax { get; private set; }

        public string DayName { get; private set; } 
        public ushort DayMax { get; private set; } 

        public string MonthName { get; private set; } 
        public ushort MonthMax { get; private set; }

        public string YearName { get; private set; }
        public ushort YearMax { get; private set; }
    }
}
