namespace EasyTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using EasyTravel.Data.Models;
    using EasyTravel.Services.Data;
    using EasyTravel.Web.ViewModels.AllProperties;
    using EasyTravel.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewsController : BaseController
    {
        private readonly IReviewsService reviewsService;
        private readonly IPropertiesService propertiesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ReviewsController(
            IReviewsService reviewsService,
            UserManager<ApplicationUser> userManager,
            IPropertiesService propertiesService)
        {
            this.reviewsService = reviewsService;
            this.userManager = userManager;
            this.propertiesService = propertiesService;
        }

        [Authorize]
        public IActionResult CreateReview(int id)
        {
            var property = this.propertiesService.GetById<CreateReviewInputModel>(id);
            return this.View(property);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateReview(CreateReviewInputModel inputModel)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.reviewsService.CreateReviewAsync(inputModel.Id, userId, inputModel.Content);
            return this.RedirectToAction("ById", "Properties", new { id = inputModel.Id });
        }
    }
}
