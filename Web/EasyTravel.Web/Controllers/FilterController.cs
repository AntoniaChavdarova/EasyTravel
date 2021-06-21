namespace EasyTravel.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Data;
    using EasyTravel.Web.ViewModels.AllProperties;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class FilterController : BaseController
    {
        private readonly IDeletableEntityRepository<Property> propertiesRepository;
        private readonly IPropertiesService propertiesService;


        public FilterController(
            IDeletableEntityRepository<Property> propertiesRepository,
            IPropertiesService propertiesService)
        {
            this.propertiesRepository = propertiesRepository;
            this.propertiesService = propertiesService;
        }

        //public JsonResult FilterByCapacity(int id, int min, int max)
        //{
        //    var properties = this.propertiesRepository.AllAsNoTracking()
        //        .Where(x => x.CategoryId == id && x.Capacity >= min && x.Capacity <= max)
        //        .ToList();

        //    return this.Json(properties);
        //}

        public IActionResult FilterByCapacity(int id, int min, int max)
        {
            var model = new PropertiesViewModel();
            model.Properties = this.propertiesService.FilterByCapacity<PropertyInListViewModel>(id, min, max);
            return this.PartialView(model);
        }
    }
}
