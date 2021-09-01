namespace EasyTravel.Web.ViewModels.AllProperties
{
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class ImagesViewModel : IMapFrom<Image>
    {
        public string RemoteImageUrl { get; set; }
    }
}