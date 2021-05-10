namespace EasyTravel.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EasyTravel.Common;
    using EasyTravel.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public City()
        {
            this.Properties = new HashSet<Property>();
        }

        [Required]
        [MinLength(GlobalConstants.DataValidations.NameMinLength)]
        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}