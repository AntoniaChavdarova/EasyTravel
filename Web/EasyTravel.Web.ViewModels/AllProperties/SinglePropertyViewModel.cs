namespace EasyTravel.Web.ViewModels.AllProperties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class SinglePropertyViewModel : IMapFrom<Property>, IHaveCustomMappings
    {
        public int Id { get; set; }
       
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public string PriceSummerr { get; set; }

        public string PriceWinter { get; set; }

        public int Capacity { get; set; }

        public string OriginalUrl { get; set; }

        public string MainImageUrl { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string CategoryName { get; set; }

        public double AverageRaiting { get; set; }

        public string CityName { get; set; }

        public IEnumerable<AmenitiessViewModel> Amenities { get; set; }

        public IEnumerable<ImagesViewModel> Images { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Property, SinglePropertyViewModel>()
                .ForMember(x => x.AverageRaiting, opt =>
                     opt.MapFrom(x => x.Ratings.Count() == 0 ? 0 : x.Ratings.Average(v => v.Value)));

        }
    }
}
