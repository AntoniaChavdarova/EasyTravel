namespace EasyTravel.Web.ViewModels.Reviews
{
    using System;

    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class ReviewViewModel : IMapFrom<Review>
    {
        public int PropertyId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public string UserUserName { get; set; }

        public byte[] UserProfilePicture { get; set; }

    }
}
