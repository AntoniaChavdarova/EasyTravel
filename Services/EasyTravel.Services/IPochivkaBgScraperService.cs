namespace EasyTravel.Services
{
    using System.Threading.Tasks;

    public interface IPochivkaBgScraperService
    {
        Task PopulateDbWithPropertiesAsync(int recipesCount);
    }
}
