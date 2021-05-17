namespace EasyTravel.Services.Data
{
    using System.Collections.Generic;

    public interface ISearchService
    {
        IEnumerable<T> SearchByCityNameAndCapacity<T>(string cityName);
    }
}
