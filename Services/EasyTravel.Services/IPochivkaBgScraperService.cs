namespace EasyTravel.Services
{
    using System.Threading.Tasks;

    public interface IPochivkaBgScraperService
    {
        Task ImportRecipesAsync(int fromId, int toId);
    }
}
