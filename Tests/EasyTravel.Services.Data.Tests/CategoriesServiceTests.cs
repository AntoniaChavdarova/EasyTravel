namespace EasyTravel.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    using Moq;
    using Xunit;

    public class CategoriesServiceTests
    {
        public CategoriesServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(TestModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public void GetAllCategoriesShouldWorksAsExpectedUsingMoq()
        {
            var moqRepository = new Mock<IDeletableEntityRepository<Category>>();
            moqRepository.Setup(x => x.AllAsNoTracking())
                .Returns(new List<Category>()
                {
                    new Category
                    {
                        Name = "Apartments",
                    },
                    new Category
                    {
                        Name = "Houses",
                    },
                }.AsQueryable());

            var categoryService = new CategoriesService(moqRepository.Object);

            var allCategories = categoryService.GetAllCategories<TestModel>();

            Assert.Equal(2, allCategories.Count());
            Assert.Equal("Apartments", allCategories.FirstOrDefault().Name);
        }

        public class TestModel : IMapFrom<Category>
        {
            public string Name { get; set; }
        }
    }
}
