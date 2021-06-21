namespace EasyTravel.Services
{
    using System;

    public interface IDateTimeParserService
    {
        DateTime ConvertStrings(string date);
    }
}
