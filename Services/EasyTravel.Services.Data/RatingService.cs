using EasyTravel.Data.Common.Repositories;
using EasyTravel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTravel.Services.Data
{
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

        public async Task SetVoteAsync(int propertyId, string userId, byte value)
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
