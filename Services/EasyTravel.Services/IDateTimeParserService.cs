using System;
using System.Collections.Generic;
using System.Text;

namespace EasyTravel.Services
{
    public interface IDateTimeParserService
    {
        DateTime ConvertStrings(string date);
    }
        
}
