namespace EasyTravel.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class SearchService : ISearchService
    {
        private readonly IDeletableEntityRepository<Property> propertiesRepository;

        public SearchService(IDeletableEntityRepository<Property> propertiesRepository)
        {
            this.propertiesRepository = propertiesRepository;
        }

        public IEnumerable<T> SearchByCityName<T>(string cityName)
        {
            var cities = this.propertiesRepository.AllAsNoTracking()
                .Where(x => x.City.Name == cityName)
                .To<T>()
                .ToList();

            return cities;
        }
    }
}
