namespace EasyTravel.Web.ViewModels.Ratings
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PostRatingInputModel
    {

        public int PropertyId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
