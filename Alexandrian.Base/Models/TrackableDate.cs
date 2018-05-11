namespace Alexandrian.Base.Models
{
    public struct TrackableDate
    {
        private ulong _datePart;

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

        public ulong DatePart
        {
            get { return _datePart; }
        }

        public TrackableDate(ushort year, ushort month, ushort day, ushort hour, ushort minute, ushort second)
        {
            Second = second;
            Minute = minute;
            Hour = hour;
            Day = day;
            Month = month;
            Year = year;

            _datePart = Second +
                (ulong)Minute * SecondMax +
                (ulong)Hour * MinuteMax * SecondMax +
                (ulong)Day * HourMax * MinuteMax * SecondMax +
                (ulong)Month * DayMax * HourMax * MinuteMax * SecondMax +
                (ulong)Year * MonthMax * DayMax * HourMax * MinuteMax * SecondMax;
        }
        public TrackableDate(ushort year, ushort month, ushort day, ushort hour, ushort minute) : this(year,month, day, hour,minute,1) { }
        public TrackableDate(ushort year, ushort month, ushort day, ushort hour) : this(year, month, day, hour, 1) { }
        public TrackableDate(ushort year, ushort month, ushort day) : this(year, month, day, 1) { }
        public TrackableDate(ushort year, ushort month) : this (year, month, 1) { }
        public TrackableDate(ushort year) : this(year, 1) { }
        public TrackableDate(ulong datePart)
        {
            _datePart = datePart;
            Second = (ushort)(datePart % SecondMax);
            datePart /= SecondMax;
            Minute = (ushort)(datePart % MinuteMax);
            datePart /= MinuteMax;
            Hour = (ushort)(datePart % HourMax);
            datePart /= HourMax;
            Day = (ushort)(datePart % DayMax);
            datePart /= DayMax;
            Month = (ushort)(datePart % MonthMax);
            datePart /= MonthMax;
            Year = (ushort)(datePart % YearMax);
            datePart /= YearMax;
        }

        public TrackableDate AddSeconds(ushort value)
        {
            return new TrackableDate(_datePart + value);
        }
        public TrackableDate AddMinutes(ushort value)
        {
            return new TrackableDate(_datePart + (ulong)value * SecondMax);
        }
        public TrackableDate AddHours(ushort value)
        {
            return new TrackableDate(_datePart + (ulong)value * MinuteMax * SecondMax);
        }
        public TrackableDate AddDays(ushort value)
        {
            return new TrackableDate(_datePart + (ulong)value * HourMax * MinuteMax * SecondMax);
        }
        public TrackableDate AddMonths(ushort value)
        {
            return new TrackableDate(_datePart + (ulong)value * DayMax * HourMax * MinuteMax * SecondMax);
        }
        public TrackableDate AddYears(ushort value)
        {
            return new TrackableDate(_datePart + (ulong)value * MonthMax * DayMax * HourMax * MinuteMax * SecondMax);
        }
        public TrackableDate SubstractSeconds(ushort value)
        {
            return new TrackableDate(_datePart - value);
        }
        public TrackableDate SubstractMinutes(ushort value)
        {
            return new TrackableDate(_datePart - (ulong)value * SecondMax);
        }
        public TrackableDate SubstractHours(ushort value)
        {
            return new TrackableDate(_datePart - (ulong)value * MinuteMax * SecondMax);
        }
        public TrackableDate SubstractDays(ushort value)
        {
            return new TrackableDate(_datePart - (ulong)value * HourMax * MinuteMax * SecondMax);
        }
        public TrackableDate SubstractMonths(ushort value)
        {
            return new TrackableDate(_datePart - (ulong)value * DayMax * HourMax * MinuteMax * SecondMax);
        }
        public TrackableDate SubstractYears(ushort value)
        {
            return new TrackableDate(_datePart - (ulong)value * MonthMax * DayMax * HourMax * MinuteMax * SecondMax);
        }
        public ulong GetDatePart()
        {
            return _datePart;
        }
    }
}
