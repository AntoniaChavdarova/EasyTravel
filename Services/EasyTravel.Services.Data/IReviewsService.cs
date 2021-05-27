namespace EasyTravel.Services.Data
{
    using System.Threading.Tasks;

    public interface IReviewsService
    {
        Task CreateReviewAsync(int propertyId, string userId, string content);
    }
}
