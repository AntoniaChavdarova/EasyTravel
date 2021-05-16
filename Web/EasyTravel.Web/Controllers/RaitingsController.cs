using EasyTravel.Services.Data;
using EasyTravel.Web.ViewModels.Ratings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EasyTravel.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaitingsController : BaseController
    {
        private readonly IRatingService ratingService;

        public RaitingsController(IRatingService ratingService)
        {
            this.ratingService = ratingService;
        }

        [HttpPost]
        [Authorize]
        //[IgnoreAntiforgeryToken]
        public async Task<ActionResult<PostRaitingResponseModel>> Post(PostRaitingInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.ratingService.SetRaitingAsync(input.PropertyId, userId, input.Value);
            var averageRaiting = this.ratingService.GetAverageVote(input.PropertyId);
            return new PostRaitingResponseModel { AverageRaiting = averageRaiting };
        }
    }
}
