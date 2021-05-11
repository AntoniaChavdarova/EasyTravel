using System;
using System.Collections.Generic;
using System.Text;

namespace EasyTravel.Services.Models
{
    public class PropertyDto
    {
        public PropertyDto()
        {
            this.Amenities = new List<string>();
            this.Images = new List<string>();

        }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string CityName { get; set; }

        public string Description { get; set; }

        public string SummerPrice { get; set; }

        public string WinterPrice { get; set; }

        public int Capacity { get; set; }

        public string OriginalUrl { get; set; }

        public List<string> Amenities { get; set; }

        public List<string> Images { get; set; }
    }
}
