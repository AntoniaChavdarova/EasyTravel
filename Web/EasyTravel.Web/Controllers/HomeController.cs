namespace EasyTravel.Web.Controllers
{
    using System.Diagnostics;

    using EasyTravel.Services;
    using EasyTravel.Services.Data;
    using EasyTravel.Web.ViewModels;
    using EasyTravel.Web.ViewModels.AllProperties;
    using EasyTravel.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IPropertiesService propertiesService;
        private readonly ISearchService searchService;
        

        public HomeController(
            ICategoriesService categoriesService,
            IPropertiesService propertiesService,
            ISearchService searchService
           )
        {
            this.categoriesService = categoriesService;
            this.propertiesService = propertiesService;
            this.searchService = searchService;
           
        }

        public IActionResult Index(InputSearchViewModel input)
        {
            var viewModel = new CategoryListViewModel
            {
                Categories = this.categoriesService.GetAllCategories<CategoryInListViewModel>(),
                TopRaitings = this.propertiesService.GetTheHighestRaitingProperties<TopRaitingsPropertiesViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult Search(string cityName)
        {
            var model = new SearchFormModel
            {
                CityName = cityName,
            };

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            return this.RedirectToAction("Results", model);
        }

        [HttpGet]
        public IActionResult Results(SearchFormModel model)
        {
            var viewModel = new PropertiesViewModel
            {
                Properties = this.searchService.SearchByCityName<PropertyInListViewModel>(model.CityName),
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
