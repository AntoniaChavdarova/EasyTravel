namespace EasyTravel.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

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
    }
}
