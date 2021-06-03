namespace EasyTravel.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using EasyTravel.Web.ViewModels.AllProperties;

    public class CategoryListViewModel : SearchFormModel
    {
        public IEnumerable<CategoryInListViewModel> Categories { get; set; }

        public IEnumerable<TopRaitingsPropertiesViewModel> TopRaitings { get; set; }
    }
}
