using System;
using System.Collections.Generic;
using System.Text;

namespace EasyTravel.Services.Data
{
    public interface ICategoriesService
    {
        IEnumerable<T> GetByCategoryName<T>(string name);

        IEnumerable<T> GetAllCategories<T>();
    }
}
