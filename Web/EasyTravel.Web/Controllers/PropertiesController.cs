namespace EasyTravel.Web.Controllers
{
    using EasyTravel.Services.Data;
    using EasyTravel.Web.ViewModels.AllProperties;
    using Microsoft.AspNetCore.Mvc;

    public class PropertiesController : BaseController
    {
        private readonly IPropertiesService propertiesService;

        public PropertiesController(IPropertiesService propertiesService)
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
    }
}
