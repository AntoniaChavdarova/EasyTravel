namespace EasyTravel.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class PropertiesService : IPropertiesService
    {
        private readonly IDeletableEntityRepository<Property> propertiesRepository;

        public PropertiesService(IDeletableEntityRepository<Property> propertiesRepository)
        {
            this.propertiesRepository = propertiesRepository;
        }

        public IEnumerable<T> GetPropertiesByCategoryName<T>(int id, int page, int itemsPerPage)
        {
            return this.propertiesRepository.AllAsNoTracking()
                .Where(x => x.Category.Id == id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var property = this.propertiesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return property;
        }

        public string GetNameByPropertyId(int id)
        {
            return this.propertiesRepository.AllAsNoTracking()
                  .FirstOrDefault(x => x.Id == id)
                  .Name
                .ToString();
        }

        public IEnumerable<T> GetTheHighestRaitingProperties<T>()
        {
            return this.propertiesRepository.AllAsNoTracking()
                .Where(x => x.Ratings.Average(y => y.Value) >= 4.5)
                .OrderBy(x => Guid.NewGuid())
                .To<T>().ToList();
        }

        public int GetCount(int id)
        {
            return this.propertiesRepository
                .AllAsNoTracking()
                .Where(x => x.Category.Id == id)
                .Count();
        }

        public IEnumerable<T> FilterByCapacity<T>(int id, int min, int max)
        {
            var query = this.propertiesRepository.AllAsNoTracking()
                .Where(x => x.CategoryId == id);

            var properties = query
                .Where(x => x.Capacity >= min && x.Capacity <= max)
                .To<T>()
                .ToList();

            return properties;
        }
    }
}