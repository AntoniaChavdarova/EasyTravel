namespace EasyTravel.Services.Data
{
    using System.Threading.Tasks;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;

    public class ReviewService : IReviewsService
    {
        private readonly IDeletableEntityRepository<Review> reviewsRepository;

        public ReviewService(IDeletableEntityRepository<Review> reviewsRepository)
        {
            this.reviewsRepository = reviewsRepository;
        }

        public async Task CreateReviewAsync(int propertyId, string userId, string content)
        {
            var review = new Review
            {
                Content = content,
                PropertyId = propertyId,
                UserId = userId,
            };

            await this.reviewsRepository.AddAsync(review);
            await this.reviewsRepository.SaveChangesAsync();
        }
    }
}
