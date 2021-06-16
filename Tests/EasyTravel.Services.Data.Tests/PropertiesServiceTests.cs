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
using EasyTravel.Web.ViewModels.Search;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;


namespace EasyTravel.Services.Data.Tests
{
    public class PropertiesServiceTests
    {
        public PropertiesServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(TestModelProp).GetTypeInfo().Assembly);
        }

        [Fact]
        public void GetTheHighestRaitingPropertiesShouldWorkCorrectly()
        {
            var rating1 = new Rating
            {
                Value = 5,
            };
            var rating2 = new Rating
            {
                Value = 6,
            };
            var rating3 = new Rating
            {
                Value = 1,
            };

            var moqRepository = new Mock<IDeletableEntityRepository<Property>>();
            moqRepository.Setup(x => x.AllAsNoTracking())
                 .Returns(new List<Property>()
                {
                    new Property
                    {
                        Name = "XXX",
                        Ratings = new List<Rating>() { rating1, rating2 },
                    },
                    new Property
                    {
                        Name = "YYY",
                        Ratings = new List<Rating>() { rating1, rating3 },
                    },
                }.AsQueryable());

            var propertiesService = new PropertiesService(moqRepository.Object);
            var listOfProperties = propertiesService.GetTheHighestRaitingProperties<TestModelProp>();

            Assert.Equal(1, listOfProperties.Count());

        }

        [Fact]
        public async Task GetByIdShouldWorkCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<Property>(new ApplicationDbContext(options.Options));
            var properties = new Property
            {
                Name = "nnnn",
                Id = 1,
            };
            await repository.AddAsync(properties);
            await repository.SaveChangesAsync();

            var propertiesService = new PropertiesService(repository);

            var result = propertiesService.GetById<TestModelProp>(1);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetNameByPropertyIdShouldWorkCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<Property>(new ApplicationDbContext(options.Options));
            var properties = new Property
            {
                Name = "Apartment SvetiVlas",
                Id = 1,
            };
            await repository.AddAsync(properties);
            await repository.SaveChangesAsync();

            var propertiesService = new PropertiesService(repository);

            var result = propertiesService.GetNameByPropertyId(1);

            Assert.Equal("Apartment SvetiVlas", result);
        }

        public class TestModelProp : IMapFrom<Property>
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public double AverageRaiting { get; set; }
        }
    }
}
