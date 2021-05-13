using EasyTravel.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTravel.Web.Controllers
{
    public class ScraperController : BaseController
    {
        private readonly IPochivkaBgScraperService pochivkaBgScraperService;

        public ScraperController(IPochivkaBgScraperService pochivkaBgScraperService)
        {
            this.pochivkaBgScraperService = pochivkaBgScraperService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Add()
        {
            await this.pochivkaBgScraperService.ImportRecipesAsync(1, 100);

            return this.RedirectToAction("Index");
        }
    }
}
