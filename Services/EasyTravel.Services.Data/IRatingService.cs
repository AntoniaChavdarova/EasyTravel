namespace EasyTravel.Services.Data
{
    using System.Threading.Tasks;

    public interface IRatingService
    {
        Task SetVoteAsync(int recipeId, string userId, byte value);

        double GetAverageVote(int recipeId);
    }
}
