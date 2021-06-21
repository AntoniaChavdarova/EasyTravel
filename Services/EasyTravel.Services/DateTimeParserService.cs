namespace EasyTravel.Services
{
    using System;
    using System.Globalization;

    using EasyTravel.Common;

    public class DateTimeParserService : IDateTimeParserService
    {
        public DateTime ConvertStrings(string date)
        {
            string dateString = date;
            string format = GlobalConstants.DateTimeFormats.DateFormat;

            DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

            return dateTime;
        }
    }
}
