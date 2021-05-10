namespace EasyTravel.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EasyTravel.Common;
    using EasyTravel.Data.Common.Models;

    public class Amenity : BaseModel<int>
    {
        public Amenity()
        {
            this.Properties = new HashSet<Property>();
        }

        [Required]
        [MinLength(GlobalConstants.DataValidations.NameMinLength)]
        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}