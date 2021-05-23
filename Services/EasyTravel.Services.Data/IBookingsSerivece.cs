namespace EasyTravel.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookingsSerivece
    {
        Task<IEnumerable<T>> MyBookings<T>(string userId);

        Task MakeBookingAsync(string userId, int propertyId, DateTime checkIn, DateTime checkOut);

        Task<T> GetByIdAsync<T>(int bookingId);

        Task DeleteAsync(int bookingId);
    }
}
