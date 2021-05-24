namespace EasyTravel.Web.ViewModels.AllProperties
{
    using System.Collections.Generic;

    public class PropertiesViewModel : PagingViewModel
    {
        public IEnumerable<PropertyInListViewModel> Properties { get; set; }
    }
}
