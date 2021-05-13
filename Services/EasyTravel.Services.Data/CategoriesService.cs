using EasyTravel.Data.Common.Repositories;
using EasyTravel.Data.Models;
using EasyTravel.Services.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace EasyTravel.Services.Data
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<T> GetAllCategories<T>()
        {
            return this.categoriesRepository.AllAsNoTracking()
                .To<T>().ToList();
        }

        public IEnumerable<T> GetByCategoryName<T>(string name)
        {
            return this.categoriesRepository.AllAsNoTracking()
                .Where(x => x.Name == name)
                 .To<T>().ToList();
        }

    }
}
