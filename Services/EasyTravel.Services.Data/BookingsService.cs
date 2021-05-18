using EasyTravel.Data.Common.Repositories;
using EasyTravel.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Services.Data
{
    public class BookingsService : IBookingsSerivece
    {
        private readonly IRepository<Booking> bookingsRepository;

        public BookingsService()
        {

        }

        public Task MakeBookingAsync(int userId, int propertyId, DateTime checkIn, DateTime checkOut)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> MyBookings<T>()
        {
            throw new NotImplementedException();
        }
    }
}
