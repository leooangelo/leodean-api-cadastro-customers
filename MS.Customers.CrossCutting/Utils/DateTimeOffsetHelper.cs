using System;
using TimeZoneConverter;

namespace MS.Customer.CrossCutting.Utils
{
    public static class DateTimeOffsetHelper
    {
        public static DateTimeOffset Instantiate(DateTime date, int hours = 0, int minutes = 0, int seconds = 0)
        {
            return Instantiate(date.Year, date.Month, date.Day, hours, minutes, seconds);
        }

        public static DateTimeOffset Instantiate(int year, int month, int day, int hours = 0, int minutes = 0, int seconds = 0)
        {
            var brazilianTimeZone = TZConvert.GetTimeZoneInfo("America/Sao_Paulo");
            var timeSpanOffset = brazilianTimeZone.GetUtcOffset(DateTimeOffset.Now);
            return new DateTimeOffset(year, month, day, hours, minutes, seconds, timeSpanOffset);
        }

        public static DateTimeOffset BrazilianDateTimeOffset
        {
            get
            {
                var brazilianTimeZone = TZConvert.GetTimeZoneInfo("America/Sao_Paulo");
                var timeSpanOffset = brazilianTimeZone.GetUtcOffset(DateTimeOffset.Now);
                return DateTimeOffset.Now.ToOffset(timeSpanOffset);
            }
        }
    }
}
