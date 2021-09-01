namespace EasyTravel.Web.ViewModels.AllProperties
{
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class AmenitiessViewModel : IMapFrom<PropertyAmenity>
    {
        public string AmenityName { get; set; }
    }
}