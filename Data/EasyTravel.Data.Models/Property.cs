namespace EasyTravel.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using EasyTravel.Common;
    using EasyTravel.Data.Common.Models;

    public class Property : BaseDeletableModel<int>
    {
        public Property()
        {
            this.Amenities = new HashSet<PropertyAmenity>();
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

        public string PriceSummerr { get; set; }

        public string PriceWinter { get; set; }

        public int Capacity { get; set; }

        public string OriginalUrl { get; set; }

        public string MainImageUrl { get; set; }

        [Required]
        [MinLength(GlobalConstants.DataValidations.AddressMinLength)]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }
    
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public ICollection<PropertyAmenity> Amenities { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
