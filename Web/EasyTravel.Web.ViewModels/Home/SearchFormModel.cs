using EasyTravel.Data.Models;
using EasyTravel.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyTravel.Web.ViewModels.Home
{
      public class SearchFormModel : IMapFrom<Property>
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a city name")]
        [StringLength(20, ErrorMessage = "The name must be at least  {1}", MinimumLength = 3)]
        [Display(Name = "Search by city")]

        public string CityName { get; set; }

           // public bool SearchInCities { get; set; }
        }
    
}
