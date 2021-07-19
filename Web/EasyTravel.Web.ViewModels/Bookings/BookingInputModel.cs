namespace EasyTravel.Web.ViewModels.Bookings
{
    using System.ComponentModel.DataAnnotations;

    using EasyTravel.Common;
    using EasyTravel.Web.Infrastructure.ValidationAttributes;

    public class BookingInputModel
    {
        [Required]
        [ValidateDateString(ErrorMessage = GlobalConstants.ErrorMessages.DateTime)]
        public string CheckIn { get; set; }

        [Required]
        [ValidateDateString(ErrorMessage = GlobalConstants.ErrorMessages.DateTime)]

        public string CheckOut { get; set; }

        public int PropertyId { get; set; }

        public string PropertyName { get; set; }

        [MinValueAttribute(1)]
        [Display(Name = "Guests count")]
        public int PeopleCount { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

    }
}
