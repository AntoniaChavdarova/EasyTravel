namespace EasyTravel.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using EasyTravel.Web.ViewModels.AllProperties;

    public class SearchViewModel
    {
        public IEnumerable<PropertyInListViewModel> Results { get; set; }
    }
}
