namespace EasyTravel.Web.ViewModels.Bookings
{
    using EasyTravel.Common;
    using EasyTravel.Web.Infrastructure.ValidationAttributes;
    using EasyTravel.Web.ViewModels.AllProperties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class BookingInputModel 
    {
        [Required]
        [ValidateDateString(ErrorMessage = GlobalConstants.ErrorMessages.DateTime)]
        public string CheckIn { get; set; }

        [Required]
        [ValidateDateString(ErrorMessage = GlobalConstants.ErrorMessages.DateTime)]

        public string CheckOut { get; set; }

        public int PropertyId { get; set; }

        public string PropName { get; set; }

        public int PeopleCount { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

    }
}
