using EasyTravel.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EasyTravel.Services
{
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
