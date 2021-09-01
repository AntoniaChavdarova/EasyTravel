namespace EasyTravel.Web.ViewModels.AllProperties
{
    using System.ComponentModel.DataAnnotations;

    using EasyTravel.Common;

    public abstract class PropertyBaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.DataValidations.NameMinLength)]
        public string Name { get; set; }

        public string PriceSummerr { get; set; }

        public int Capacity { get; set; }

        public string MainImageUrl { get; set; }

        public double AverageRaiting { get; set; }
    }
}
