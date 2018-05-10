namespace Alexandrian.Base.Models
{
    public struct TrackableDate
    {
        public ushort Second { get; private set; }
        public static string SecondName { get; private set; } = "Second";
        internal static ushort SecondMax { get; private set; } = 60;

        public ushort Minute { get; private set; }
        public static string MinuteName { get; private set; } = "Day";
        internal static ushort MinuteMax { get; private set; } = 60;

        public ushort Hour { get; private set; }
        public static string HourName { get; private set; } = "Hour";
        internal static ushort HourMax { get; private set; } = 24;

        public ushort Day { get; private set; }
        public static string DayName { get; private set; } = "Day";
        internal static ushort DayMax { get; private set; } = 30;

        public ushort Month { get; private set; }
        public static string MonthName { get; private set; } = "Month";
        internal static ushort MonthMax { get; private set; } = 12;

        public ushort Year { get; private set; }
        public static string YearName { get; private set; } = "Year";
        internal static ushort YearMax { get; private set; } = 9999;


        public TrackableDate(ushort year, ushort month, ushort day, ushort hour, ushort minute, ushort second)
        {
            Second = second;
            Minute = minute;
            Hour = hour;
            Day = day;
            Month = month;
            Year = year;
        }
        public TrackableDate(ushort year, ushort month, ushort day, ushort hour, ushort minute)
        {
            Second = 1;
            Minute = minute;
            Hour = hour;
            Day = day;
            Month = month;
            Year = year;
        }
        public TrackableDate(ushort year, ushort month, ushort day, ushort hour)
        {
            Second = 1;
            Minute = 1;
            Hour = hour;
            Day = day;
            Month = month;
            Year = year;
        }
        public TrackableDate(ushort year, ushort month, ushort day)
        {
            Second = 1;
            Minute = 1;
            Hour = 1;
            Day = day;
            Month = month;
            Year = year;
        }
        public TrackableDate(ushort year, ushort month)
        {
            Second = 1;
            Minute = 1;
            Hour = 1;
            Day = 1;
            Month = month;
            Year = year;
        }
        public TrackableDate(ushort year)
        {
            Second = 1;
            Minute = 1;
            Hour = 1;
            Day = 1;
            Month = 1;
            Year = year;
        }
    }
}
