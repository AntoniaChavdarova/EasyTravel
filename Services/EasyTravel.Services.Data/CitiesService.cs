namespace EasyTravel.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> citiesRepository;

        public CitiesService(IDeletableEntityRepository<City> citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public IEnumerable<T> GetAllCitiesBySearchName<T>(string name)
        {
            var cities = this.citiesRepository.AllAsNoTracking()
                .Where(x => x.Name.Contains(name))
                .To<T>()
                .ToList();

            return cities;
        }

    }
}
