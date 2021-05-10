namespace EasyTravel.Data.Models
{
    using System.Collections.Generic;

    using EasyTravel.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Properties = new HashSet<Property>();
        }

        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}
