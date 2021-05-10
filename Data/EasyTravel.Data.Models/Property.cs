namespace EasyTravel.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using EasyTravel.Common;
    using EasyTravel.Data.Common.Models;

    public class Property : BaseDeletableModel<string>
    {
        public Property()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Amenities = new HashSet<Amenity>();
            this.Bookings = new HashSet<Booking>();
            this.Images = new HashSet<Image>();
            this.Ratings = new HashSet<Rating>();
            this.Reviews = new HashSet<Review>();
        }

        [Required]
        [MinLength(GlobalConstants.DataValidations.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(GlobalConstants.DataValidations.DescriptionMinLength)]
        public string Description { get; set; }

        public decimal SummerPrice { get; set; }

        public decimal WinterPrice { get; set; }

        public int Capacity { get; set; }

        public string OriginalUrl { get; set; }

        [DefaultValue(true)]
        public bool IsAvailable { get; set; }

        [Required]
        [MinLength(GlobalConstants.DataValidations.AddressMinLength)]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public int ContactFormId { get; set; }

        public virtual ContactForm ContactForm { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<Amenity> Amenities { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
