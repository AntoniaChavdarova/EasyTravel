namespace EasyTravel.Services.Data
{
    using System.Collections.Generic;

    public interface ISearchService
    {
        IEnumerable<T> SearchByCityName<T>(string cityName);
    }
}
