using EasyTravel.Web.ViewModels.AllProperties;
using EasyTravel.Web.ViewModels.Search;
using System.Collections.Generic;

namespace EasyTravel.Web.ViewModels.Home
{
    public class CategoryListViewModel : SearchFormModel
    {
        public IEnumerable<CategoryInListViewModel> Categories { get; set; }

        public IEnumerable<TopRaitingsPropertiesViewModel> TopRaitings { get; set; }

        public IEnumerable<SearchResponseModel> Cities { get; set; }
    }
}
