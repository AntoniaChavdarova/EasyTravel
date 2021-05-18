namespace EasyTravel.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EasyTravel.Data.Common.Models;

    public class Booking : BaseDeletableModel<int>
    {
        public int PeopleCount { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

        // The Salon can Confirm or Decline an appointment
        public bool? Confirmed { get; set; }
    }
}
