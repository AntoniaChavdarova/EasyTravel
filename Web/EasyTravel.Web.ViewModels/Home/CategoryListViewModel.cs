using System.Collections.Generic;

namespace EasyTravel.Web.ViewModels.Home
{
    public class CategoryListViewModel
    {
        public IEnumerable<CategoryInListViewModel> Categories { get; set; }
    }
}
