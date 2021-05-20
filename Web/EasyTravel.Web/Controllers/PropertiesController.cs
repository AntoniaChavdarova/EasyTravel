namespace EasyTravel.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using EasyTravel.Services;
    using EasyTravel.Services.Data;
    using EasyTravel.Web.ViewModels.AllProperties;
    using EasyTravel.Web.ViewModels.Bookings;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PropertiesController : BaseController
    {
        private readonly IPropertiesService propertiesService;

        public PropertiesController(
            IPropertiesService propertiesService)
        {
            this.propertiesService = propertiesService;
        }

        public IActionResult GetAllByCategory(int id)
        {
            var viewModel = new PropertiesViewModel
            {
                Properties = this.propertiesService.GetPropertiesByCategoryName<PropertyInListViewModel>(id),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var recipe = this.propertiesService.GetById<SinglePropertyViewModel>(id);
            return this.View(recipe);
        }

    }
}
