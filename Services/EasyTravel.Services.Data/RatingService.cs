namespace EasyTravel.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;

    public class RatingService : IRatingService
    {
        private readonly IRepository<Rating> ratingsRepository;

        public RatingService(IRepository<Rating> ratingsRepository)
        {
            this.ratingsRepository = ratingsRepository;
        }

        public double GetAverageVote(int propertyId)
        {
            return this.ratingsRepository.All()
                .Where(x => x.PropertyId == propertyId)
                .Average(x => x.Value);
        }

        public async Task SetRaitingAsync(int propertyId, string userId, byte value)
        {
            var rating = this.ratingsRepository.All()
                .FirstOrDefault(x => x.UserId == userId && x.PropertyId == propertyId);

            if (rating == null)
            {
                rating = new Rating
                {
                    PropertyId = propertyId,
                    UserId = userId,
                };

                await this.ratingsRepository.AddAsync(rating);
            }

            rating.Value = value;
            await this.ratingsRepository.SaveChangesAsync();
        }
    }
}
