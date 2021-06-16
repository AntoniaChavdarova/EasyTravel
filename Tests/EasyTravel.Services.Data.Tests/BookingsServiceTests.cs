namespace EasyTravel.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using EasyTravel.Data;
    using EasyTravel.Data.Models;
    using EasyTravel.Data.Repositories;
    using EasyTravel.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class BookingsServiceTests
    {
        private readonly EfDeletableEntityRepository<Booking> repositoryBooking;
        private readonly EfDeletableEntityRepository<Property> repositoryProperty;

        public BookingsServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(BookingTestModel).GetTypeInfo().Assembly);
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(Guid.NewGuid().ToString());
            this.repositoryBooking = new EfDeletableEntityRepository<Booking>(new ApplicationDbContext(options.Options));
            this.repositoryProperty = new EfDeletableEntityRepository<Property>(new ApplicationDbContext(options.Options));
        }

        [Fact]
        public async Task MyBookingsShoulReturnAllBookingForUserId()
        {
            var booking1 = new Booking
            {
                Id = 1,
                UserId = "abc",
            };
            var booking2 = new Booking
            {
                Id = 2,
                UserId = "bbb",
            };
            await this.repositoryBooking.AddAsync(booking2);
            await this.repositoryBooking.AddAsync(booking1);
            await this.repositoryBooking.SaveChangesAsync();

            var service = new BookingsService(this.repositoryBooking, this.repositoryProperty);
            var list = await service.MyBookings<BookingTestModel>("abc");

            Assert.Equal(1, list.Count());
        }

        [Fact]
        public async Task ShoulDeleteBookingForUserId()
        {
            var booking1 = new Booking
            {
                Id = 1,
                UserId = "abc",
            };
            var booking2 = new Booking
            {
                Id = 2,
                UserId = "bbb",
            };
            await this.repositoryBooking.AddAsync(booking2);
            await this.repositoryBooking.AddAsync(booking1);
            await this.repositoryBooking.SaveChangesAsync();

            var service = new BookingsService(this.repositoryBooking, this.repositoryProperty);
            await service.DeleteAsync(1);

            Assert.Equal(1, this.repositoryBooking.All().Count());
            Assert.Equal(2, this.repositoryBooking.AllWithDeleted().Count());
        }

        [Fact]
        public async Task GetByIdAsyncShouldWorkCorrect()
        {
            var booking1 = new Booking
            {
                Id = 1,
                UserId = "abc",
            };
            var booking2 = new Booking
            {
                Id = 2,
                UserId = "bbb",
            };
            await this.repositoryBooking.AddAsync(booking2);
            await this.repositoryBooking.AddAsync(booking1);
            await this.repositoryBooking.SaveChangesAsync();

            var service = new BookingsService(this.repositoryBooking, this.repositoryProperty);
            var list = await service.GetByIdAsync<BookingTestModel>(1);

            Assert.Equal(1, list.Id);
        }

        public class BookingTestModel : IMapFrom<Booking>
        {
            public int Id { get; set; }

            //public int PeopleCount { get; set; }

            //public DateTime CheckIn { get; set; }

            //public DateTime CheckOut { get; set; }

            public string UserId { get; set; }

            //public int PropertyId { get; set; }

            //public string PropertyName { get; set; }

            //public bool? Confirmed { get; set; }
        }
    }
}
