using EasyTravel.Data.Models;
using EasyTravel.Services.Mapping;


namespace EasyTravel.Web.ViewModels.AllProperties
{
    public class ImagesViewModel : IMapFrom<Image>
    {
        public string RemoteImageUrl { get; set; }
    }
}