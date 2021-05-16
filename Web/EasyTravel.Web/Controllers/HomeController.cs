namespace EasyTravel.Web.Controllers
{
    using System.Diagnostics;
    using EasyTravel.Services.Data;
    using EasyTravel.Web.ViewModels;
    using EasyTravel.Web.ViewModels.AllProperties;
    using EasyTravel.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IPropertiesService propertiesService;

        public HomeController(
            ICategoriesService categoriesService,
            IPropertiesService propertiesService)
        {
            this.categoriesService = categoriesService;
            this.propertiesService = propertiesService;
        }

        public IActionResult Index()
        {
            var viewModel = new CategoryListViewModel
            {
                Categories = this.categoriesService.GetAllCategories<CategoryInListViewModel>(),
                TopRaitings = this.propertiesService.GetTheHighestRaitingProperties<TopRaitingsPropertiesViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
