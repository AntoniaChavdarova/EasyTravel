namespace EasyTravel.Web.Controllers
{
    using EasyTravel.Services.Data;
    using EasyTravel.Web.ViewModels.AllProperties;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class FilterController : BaseController
    {
        private readonly IPropertiesService propertiesService;

        public FilterController(IPropertiesService propertiesService)
        {
            this.propertiesService = propertiesService;
        }

        public IActionResult FilterByCapacity(int id, int min, int max)
        {
            var model = new PropertiesViewModel();
            model.Properties = this.propertiesService.FilterByCapacity<PropertyInListViewModel>(id, min, max);
            return this.PartialView(model);
        }
    }
}
