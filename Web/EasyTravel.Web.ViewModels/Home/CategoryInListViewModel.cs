namespace EasyTravel.Web.ViewModels.Home
{
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class CategoryInListViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string RemoteImageUrl { get; set; }

    }
}