namespace EasyTravel.Services.Data
{
    using System.Collections.Generic;

    public interface IPropertiesService
    {
        public IEnumerable<T> GetPropertiesByCategoryName<T>(int id, int page, int itemsPerPage);

        public IEnumerable<T> FilterByCapacity<T>(int id, int min, int max);

        public T GetById<T>(int id);

        public IEnumerable<T> GetTheHighestRaitingProperties<T>();

        string GetNameByPropertyId(int id);

        int GetCount(int id);
    }
}
