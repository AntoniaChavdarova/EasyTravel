using EasyTravel.Data;
using EasyTravel.Data.Models;
using EasyTravel.Data.Repositories;
using EasyTravel.Services.Mapping;
using EasyTravel.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyTravel.Services.Data.Tests
{
    public class ReviewServiceTests
    {
        public ReviewServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public async Task AddNewReviewShouldSaveContactFormsCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<Review>(new ApplicationDbContext(options.Options));
            var reviewService = new ReviewService(repository);

            await reviewService.CreateReviewAsync(1, "1", "LoremIpsum");
            await reviewService.CreateReviewAsync(2, "12", "LoremIpsumLoremIpsum");

            Assert.Equal(2, repository.All().Count());
        }
    }
}
