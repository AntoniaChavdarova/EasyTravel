using EasyTravel.Data.Common.Repositories;
using EasyTravel.Data.Models;
using EasyTravel.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTravel.Services.Data
{
    public class PropertiesService : IPropertiesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Property> propertiesRepository;

        public PropertiesService(
            IDeletableEntityRepository<Category> categoriesRepository,
            IDeletableEntityRepository<Property> propertiesRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.propertiesRepository = propertiesRepository;
        }

        public IEnumerable<T> GetPropertiesByCategoryName<T>(int id)
        {
            return this.propertiesRepository.AllAsNoTracking()
                .Where(x => x.Category.Id == id)
                .To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var recipe = this.propertiesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return recipe;
        }

    }
}

