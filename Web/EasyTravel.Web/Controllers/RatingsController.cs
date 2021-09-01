namespace EasyTravel.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using EasyTravel.Services.Data;
    using EasyTravel.Web.ViewModels.Ratings;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : BaseController
    {
        private readonly IRatingService ratingService;

        public RatingsController(IRatingService ratingService)
        {
            this.ratingService = ratingService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostRatingResponseModel>> Post(PostRatingInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.ratingService.SetRaitingAsync(input.PropertyId, userId, input.Value);
            var averageRating = this.ratingService.GetAverageVote(input.PropertyId);
            return new PostRatingResponseModel { AverageRating = averageRating };
        }
    }
}
