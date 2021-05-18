namespace EasyTravel.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class BookingsService : IBookingsSerivece
    {
        private readonly IRepository<Booking> bookingsRepository;

        public BookingsService(IRepository<Booking> bookingsRepository)
        {
            this.bookingsRepository = bookingsRepository;
        }


        public async Task MakeBookingAsync(string userId, int propertyId, DateTime checkIn, DateTime checkOut)
        {
            if (!this.IsDatesValid(checkIn, checkOut))
            {
                throw new Exception($"Invalid dates");
            }

            if (!this.IsDatesAvailable(propertyId, checkIn, checkOut))
            {
                throw new Exception($"The dates are not available dates");
            }

            var booking = this.bookingsRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.UserId == userId && x.PropertyId == propertyId);

            if (booking == null)
            {
                booking = new Booking
                {
                    UserId = userId,
                    PropertyId = propertyId,
                };

                await this.bookingsRepository.AddAsync(booking);
            }

            booking.CheckIn = checkIn;
            booking.CheckOut = checkOut;

            await this.bookingsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> MyBookings<T>(string userId)
        {
            return this.bookingsRepository.AllAsNoTracking()
                .Where(x => x.UserId == userId)
                .To<T>()
                .ToList();
        }

        private bool IsDatesAvailable(int propertyId, DateTime checkIn, DateTime checkOut)
        {
            var booking = this.bookingsRepository.AllAsNoTracking()
               .FirstOrDefault( x => x.PropertyId == propertyId && x.CheckIn == checkIn && x.CheckOut == checkOut);

            if (booking == null)
            {
                return true;
            }

            return false;
        }

        private bool IsDatesValid(DateTime checkIn, DateTime checkOut)
        {
            if (checkIn > checkOut)
            {
                return false;
            }

            return true;
        }
    }
}
