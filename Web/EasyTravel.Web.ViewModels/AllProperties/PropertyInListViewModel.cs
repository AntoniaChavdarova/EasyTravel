namespace EasyTravel.Web.ViewModels.AllProperties
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using EasyTravel.Common;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class PropertyInListViewModel : IMapFrom<Property>, IHaveCustomMappings
    {
        [Required]
        [MinLength(GlobalConstants.DataValidations.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(GlobalConstants.DataValidations.DescriptionMinLength)]
        public string Description { get; set; }

        public string PriceSummerr { get; set; }

        public int Capacity { get; set; }

        public string OriginalUrl { get; set; }

        [Required]
        [MinLength(GlobalConstants.DataValidations.AddressMinLength)]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string CityName { get; set; }

        public int CityId { get; set; }

        public string MainImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Property, PropertyInListViewModel>()
            .ForMember(x => x.Description, opt =>
            opt.MapFrom(x =>
            x.Description.Length > 200 ?
            x.Description.Substring(14, 200) + "......." : x.Description));
        }
    }
}
