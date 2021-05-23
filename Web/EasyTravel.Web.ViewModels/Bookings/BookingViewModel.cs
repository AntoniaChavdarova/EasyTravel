namespace EasyTravel.Web.ViewModels.Bookings
{
    using System;

    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class BookingViewModel : IMapFrom<Booking>
    {
        public int PeopleCount { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public int PropertyId { get; set; }

        public string PropertyAddress { get; set; }

        public string PropertyName { get; set; }

        public string PropertyCityName { get; set; }

        // The Salon can Confirm or Decline an appointment
        public bool? Confirmed { get; set; }
    }
}