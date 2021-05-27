namespace EasyTravel.Web.ViewModels.Reviews
{
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class ReviewViewModel : IMapFrom<Review>
    {
        public int PropertyId { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

    }
}
