namespace EasyTravel.Services.Data
{
    using EasyTravel.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICitiesService
    {
     IEnumerable<T> GetAllCitiesBySearchName<T>(string name);

       


    }
}
