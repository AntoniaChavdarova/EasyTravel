namespace EasyTravel.Web.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;

    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class SearchFormModel : IMapFrom<Property>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a city name")]
        [StringLength(20, ErrorMessage = "The name must be at least  {1}", MinimumLength = 3)]
        [Display(Name = "Search by city")]

        public string CityName { get; set; }
    }
}
