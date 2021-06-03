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

        //public ActionResult<SearchResponseModelInList> AutocompleteSearch(string search)
        //     {
        //         var cities = this.citiesService.GetAllCitiesBySearchName<SearchResponseModel>(search);

        //         return new SearchResponseModelInList { Cities = cities.ToList() };
        //     }

        public JsonResult AutoComplete(string search)
        {
            var cities = this.citiesRepository.AllAsNoTracking()
                .Where(x => x.Name.Contains(search))
                .ToList();

            return this.Json(cities);
        }
    }
}