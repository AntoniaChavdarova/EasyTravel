namespace EasyTravel.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using EasyTravel.Data;
    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Data.Repositories;
    using EasyTravel.Services.Mapping;
    using EasyTravel.Web.ViewModels;
    using EasyTravel.Web.ViewModels.AllProperties;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class SearchServiceTests
    {
        public SearchServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(TestModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public void SearchFunctionShouldWorksCorrectly()
        {
            var city1 = new City
            {
                Name = "Burgas",
            };

            var city2 = new City
            {
                Name = "Varna",
            };

            var moqRepository = new Mock<IDeletableEntityRepository<Property>>();
            _ = moqRepository.Setup(x => x.AllAsNoTracking())
                .Returns(new List<Property>()
                {
                    new Property
                    {
                        Name = "XXX",
                        City = city1,
                    },
                    new Property
                    {
                        Name = "YYY",
                        City = city2,
                    },
                }.AsQueryable());

            var searchService = new SearchService(moqRepository.Object);
            var allProperties = searchService.SearchByCityName<TestModel>("Varna");

            Assert.Equal(1, allProperties.Count());
        }

        public class TestModel : IMapFrom<Property>
        {
            public string CityName { get; set; }

            public string Name { get; set; }

            public int CityId { get; set; }
        }
    }
}
