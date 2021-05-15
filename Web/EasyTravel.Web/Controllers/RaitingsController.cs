using EasyTravel.Services.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
