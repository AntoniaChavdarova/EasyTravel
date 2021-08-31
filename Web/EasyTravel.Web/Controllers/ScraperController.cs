namespace EasyTravel.Web.Controllers
{
    using System.Threading.Tasks;

    using EasyTravel.Services;
    using Microsoft.AspNetCore.Mvc;

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
            await this.pochivkaBgScraperService.ImportRecipesAsync(1, 300);

            return this.RedirectToAction("Index");
        }
    }
}
