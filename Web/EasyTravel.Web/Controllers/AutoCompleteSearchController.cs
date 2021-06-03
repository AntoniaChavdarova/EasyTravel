using EasyTravel.Services.Data;
using EasyTravel.Web.ViewModels.Home;
using EasyTravel.Web.ViewModels.Search;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTravel.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoCompleteSearchController : BaseController
    {
       private readonly ICitiesService citiesService;

       public AutoCompleteSearchController(ICitiesService citiesService)
            {
                this.citiesService = citiesService;
            }

       public ActionResult<SearchResponseModelInList> AutocompleteSearch(string search)
            {
                var cities = this.citiesService.GetAllCitiesBySearchName<SearchResponseModel>(search);

                return new SearchResponseModelInList { Cities = cities };

            }
        }
    }

