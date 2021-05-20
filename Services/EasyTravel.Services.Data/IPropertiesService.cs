namespace EasyTravel.Services.Data
{
    using System.Collections.Generic;

    public interface IPropertiesService
    {
        public IEnumerable<T> GetPropertiesByCategoryName<T>(int id);

        public T GetById<T>(int id);

        public IEnumerable<T> GetTheHighestRaitingProperties<T>();

        string GetNameByPropertyId(int id);
    }
}
