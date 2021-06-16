namespace EasyTravel.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;
    using EasyTravel.Web.ViewModels;
    using EasyTravel.Web.ViewModels.Search;
    using Moq;
    using Xunit;

    public class CitiesServiceTests
    {
        public CitiesServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public void GetAllCitiesBySearchNameShouldWorksAsExpectedUsingMoq()
        {
            var moqRepository = new Mock<IDeletableEntityRepository<City>>();
            moqRepository.Setup(x => x.AllAsNoTracking())
                .Returns(new List<City>()
                {
                    new City
                    {
                        Name = "Sofia",
                    },
                    new City
                    {
                        Name = "Silistra",
                    },
                    new City
                    {
                        Name = "Varna",
                    },

                }.AsQueryable());

            var citiesService = new CitiesService(moqRepository.Object);

            var allCities = citiesService.GetAllCitiesBySearchName<SearchResponseModel>("S");

            Assert.Equal(2, allCities.Count());
            Assert.DoesNotContain(new SearchResponseModel{Name = "Varna"}, allCities);
            Assert.Equal("Sofia", allCities.FirstOrDefault().Name);
        }

    }
}
