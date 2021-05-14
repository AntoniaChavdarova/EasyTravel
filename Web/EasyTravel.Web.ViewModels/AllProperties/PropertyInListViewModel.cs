using AutoMapper;
using EasyTravel.Common;
using EasyTravel.Data.Models;
using EasyTravel.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EasyTravel.Web.ViewModels.AllProperties
{
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

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Property, PropertyInListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                     opt.MapFrom(x =>
                       x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/images/props/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));

        }

    }
}
