namespace EasyTravel.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class BookingsService : IBookingsSerivece
    {
        private readonly IDeletableEntityRepository<Booking> bookingsRepository;
        private readonly IDeletableEntityRepository<Property> propertiesRepository;

        public BookingsService(
            IDeletableEntityRepository<Booking> bookingsRepository,
            IDeletableEntityRepository<Property> propertiesRepository)
        {
            this.bookingsRepository = bookingsRepository;
            this.propertiesRepository = propertiesRepository;
        }

        public async Task MakeBookingAsync(string userId, int propertyId, DateTime checkIn, DateTime checkOut, int guestsCount)
        {
            if (!this.IsDatesValid(checkIn, checkOut))
            {
                throw new Exception($"Invalid dates");
            }

            if (!this.IsDatesAvailable(propertyId, checkIn, checkOut))
            {
                throw new Exception($"The dates are not available ");
            }

            if (!this.IsDatesBetweenExistingReservation(propertyId, checkIn, checkOut))
            {
                throw new Exception($"The dates are not available ");
            }

            if (!this.IsCheckInBettweenExistingReservation(propertyId, checkIn, checkOut))
            {
                throw new Exception($"The dates are not available ");
            }

            if (!this.IsCheckOutBettweenExistingReservation(propertyId, checkIn, checkOut))
            {
                throw new Exception($"The dates are not available ");
            }

            if (this.ProperyMaxGuestCount(propertyId) < guestsCount)
            {
                throw new Exception($"The Capacity of the property it is not enough");
            }

            var booking = this.bookingsRepository.All()
                .FirstOrDefault(x => x.UserId == userId && x.PropertyId == propertyId && x.CheckIn == checkIn && x.CheckOut == checkOut);

            if (booking == null)
            {
                booking = new Booking
                {
                    UserId = userId,
                    PropertyId = propertyId,
                    CheckIn = checkIn,
                    CheckOut = checkOut,
                    PeopleCount = guestsCount,
                };

                await this.bookingsRepository.AddAsync(booking);
            }

            await this.bookingsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> MyBookings<T>(string userId)
        {
            return await this.bookingsRepository.AllWithDeleted()
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.CheckIn)
                .To<T>()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            return

                 await this.bookingsRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var booking =
                await this.bookingsRepository
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            this.bookingsRepository.Delete(booking);
            await this.bookingsRepository.SaveChangesAsync();
        }

        private bool IsDatesBetweenExistingReservation(int propertyId, DateTime checkIn, DateTime checkOut)
        {
            var booking = this.bookingsRepository.AllAsNoTracking()
             .FirstOrDefault(x => x.PropertyId == propertyId && checkIn >= x.CheckIn && checkOut <= x.CheckOut);

            if (booking == null)
            {
                return true;
            }

            return false;
        }

        private bool IsCheckInBettweenExistingReservation(int propertyId, DateTime checkIn, DateTime checkOut)
        {
            var booking = this.bookingsRepository.AllAsNoTracking()
             .FirstOrDefault(x => x.PropertyId == propertyId && checkIn >= x.CheckIn && checkIn < x.CheckOut
             || x.PropertyId == propertyId && checkIn < x.CheckIn && checkOut <= x.CheckOut && checkOut > x.CheckIn);

            if (booking == null)
            {
                return true;
            }

            return false;


        }

        private bool IsCheckOutBettweenExistingReservation(int propertyId, DateTime checkIn, DateTime checkOut)
        {
            var booking = this.bookingsRepository.AllAsNoTracking()
             .FirstOrDefault(x => x.PropertyId == propertyId && checkOut > x.CheckIn && checkOut <= x.CheckOut);

            if (booking == null)
            {
                return true;
            }

            return false;
        }

        private bool IsDatesAvailable(int propertyId, DateTime checkIn, DateTime checkOut)
        {
            var booking = this.bookingsRepository.AllAsNoTracking()
               .FirstOrDefault(x => x.PropertyId == propertyId && x.CheckIn == checkIn && x.CheckOut == checkOut);

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

            if (checkIn < DateTime.UtcNow && checkOut <= DateTime.UtcNow)
            {
                return false;
            }

            return true;
        }

        private int ProperyMaxGuestCount(int propertyId)
        {
            var maxGuestCount = this.propertiesRepository
                .All()
                .FirstOrDefault(x => x.Id == propertyId)
                .Capacity;

            return maxGuestCount;
        }
    }
}
