namespace EasyTravel.Web.Controllers
{
    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Data;
    using EasyTravel.Web.ViewModels.AllProperties;
    using EasyTravel.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Mvc;

    public class PropertiesController : BaseController
    {
        private readonly IPropertiesService propertiesService;

        public PropertiesController(
            IPropertiesService propertiesService,
            IDeletableEntityRepository<Property> propertiesRepository)
        {
            this.propertiesService = propertiesService;
        }

        public IActionResult GetAllByCategory(int id, int pageId = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 10;

            var viewModel = new PropertiesViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = pageId,
                PropertiesCount = this.propertiesService.GetCount(id),
                Properties = this.propertiesService.GetPropertiesByCategoryName<PropertyInListViewModel>(id, pageId, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {

            var property = this.propertiesService.GetById<SinglePropertyViewModel>(id);

            if (property == null)
            {
                return this.NotFound();
            }

            return this.View(property);
        }
    }
}
