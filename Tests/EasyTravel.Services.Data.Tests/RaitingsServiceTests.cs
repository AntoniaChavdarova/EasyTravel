namespace EasyTravel.Services.Data.Tests
{
    using System;
    using System.Threading.Tasks;

    using EasyTravel.Data;
    using EasyTravel.Data.Models;
    using EasyTravel.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class RaitingsServiceTests
    {
        [Fact]
        public async Task SetRaitingAsyncShouldWorkCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfRepository<Rating>(new ApplicationDbContext(options.Options));
            var service = new RatingService(repository);

            await service.SetRaitingAsync(1, "1", 5);
            await service.SetRaitingAsync(1, "1", 4);
            await service.SetRaitingAsync(1, "1", 3);
            var votes = service.GetAverageVote(1);

            Assert.Equal(3, votes);
        }

        [Fact]
        public async Task GetAverageVoteShouldWorkCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfRepository<Rating>(new ApplicationDbContext(options.Options));
            var service = new RatingService(repository);

            await service.SetRaitingAsync(1, "1", 5);
            await service.SetRaitingAsync(1, "2", 4);
            await service.SetRaitingAsync(1, "3", 3);
            var votes = service.GetAverageVote(1);

            Assert.Equal(4, votes);
        }
    }
}
