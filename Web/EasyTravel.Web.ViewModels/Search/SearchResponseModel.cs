namespace EasyTravel.Web.ViewModels.Search
{
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class SearchResponseModel : IMapFrom<City>
    {
        public string Name { get; set; }
    }
}