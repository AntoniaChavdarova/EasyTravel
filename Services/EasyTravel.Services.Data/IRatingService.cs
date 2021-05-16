namespace EasyTravel.Services.Data
{
    using System.Threading.Tasks;

    public interface IRatingService
    {
        Task SetRaitingAsync(int propertyId, string userId, byte value);

        double GetAverageVote(int propertyId);
    }
}
