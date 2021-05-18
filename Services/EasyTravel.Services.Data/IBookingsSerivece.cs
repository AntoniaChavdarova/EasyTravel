using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyTravel.Services.Data
{
    public interface IBookingsSerivece
    {
         IEnumerable<T> MyBookings<T>();

        Task MakeBookingAsync(int userId, int propertyId, DateTime checkIn, DateTime checkOut);


    }
}
