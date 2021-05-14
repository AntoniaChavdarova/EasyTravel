using EasyTravel.Data.Models;
using EasyTravel.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyTravel.Web.ViewModels.AllProperties
{
    public class SinglePropertyViewModel : IMapFrom<Property>
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

        public string CityName { get; set; }

        public IEnumerable<AmenitiessViewModel> Amenities { get; set; }

        public IEnumerable<ImagesViewModel> Images { get; set; }


    }
}
