using EasyTravel.Data.Models;
using EasyTravel.Services.Mapping;

namespace EasyTravel.Web.ViewModels.AllProperties
{
    public class AmenitiessViewModel : IMapFrom<PropertyAmenity>
    {
        public string AmenityName { get; set; }
    }
}