namespace EasyTravel.Web.Controllers
{
    using System.Linq;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class AutoCompleteSearchController : BaseController
    {
        private readonly ICitiesService citiesService;
        private readonly IDeletableEntityRepository<City> citiesRepository;

        public AutoCompleteSearchController(
            ICitiesService citiesService,
            IDeletableEntityRepository<City> citiesRepository)
        {
            this.citiesService = citiesService;
            this.citiesRepository = citiesRepository;
        }

        public JsonResult AutoComplete(string search)
        {
            var cities = this.citiesRepository.AllAsNoTracking()
                .Where(x => x.Name.StartsWith(search))
                .ToList();

            return this.Json(cities);
        }
    }
}