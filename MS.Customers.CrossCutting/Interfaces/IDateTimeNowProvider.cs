using System;

namespace MS.Customer.CrossCutting
{
    public interface IDateTimeNowProvider
    {
        DateTime CurrentDate { get; }
        DateTime CurrentDateTime { get; }
        TimeSpan CurrentTimeSpan { get; }
        DayOfWeek CurrentDayOfWeek { get; }
        bool IsHigherThanToday(DateTime dateTime, TimeSpan? timeSpan = null);
    }
}
