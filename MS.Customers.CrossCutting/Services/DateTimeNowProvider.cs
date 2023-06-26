using System;
using TimeZoneConverter;

namespace MS.Customer.CrossCutting.Services
{
    public class DateTimeNowProvider : IDateTimeNowProvider
    {
        public DateTime CurrentDate => CurrentDateTime.Date;
        public DateTime CurrentDateTime => TimeZoneInfo.ConvertTime(DateTime.Now, TZConvert.GetTimeZoneInfo("America/Sao_Paulo"));
        //public DateTime CurrentDateTime => DateTimeOffsetHelper.BrazilianDateTimeOffset.LocalDateTime;
        public TimeSpan CurrentTimeSpan => CurrentDateTime.TimeOfDay;
        public DayOfWeek CurrentDayOfWeek => CurrentDateTime.DayOfWeek;

        public bool IsHigherThanToday(DateTime dateTime, TimeSpan? timeSpan = null)
        {
            //var teste = $"LocalDateTime = {CurrentDateTime} && offset = { DateTimeOffsetHelper.BrazilianDateTimeOffset}";
            //throw new Exception(teste);

            DateTime date;

            if (timeSpan.HasValue)
                date = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                timeSpan.Value.Hours, timeSpan.Value.Minutes, timeSpan.Value.Seconds);
            else
                date = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);

            return date > CurrentDateTime;
        }
    }
}
