namespace EasyTravel.Web.ViewModels.Bookings
{
    using System.Collections.Generic;

    public class BookingsListViewModel
    {
        public IEnumerable<BookingViewModel> MyBookings { get; set; }
    }
}
