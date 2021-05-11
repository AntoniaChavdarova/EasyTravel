using AngleSharp;
using EasyTravel.Data.Common.Repositories;
using EasyTravel.Data.Models;
using System.Threading.Tasks;

namespace EasyTravel.Services
{
    public class PochivkaBgScraperService : IPochivkaBgScraperService
    {
        private const string BaseUrl = "https://recepti.gotvach.bg/r-{0}";

        private readonly IBrowsingContext context;
        private readonly IDeletableEntityRepository<Property> propertyRepository;
        private readonly IRepository<Amenity> amenitiesRepository;
        private readonly IRepository<Image> imagesRepository;

        public PochivkaBgScraperService(
            IDeletableEntityRepository<Property> propertyRepository,
            IRepository<Amenity> amenitiesRepository,
            IRepository<Image> imagesRepository)
        {
            this.propertyRepository = propertyRepository;
            this.amenitiesRepository = amenitiesRepository;
            this.imagesRepository = imagesRepository;

            var config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(config);
        }

        public Task PopulateDbWithPropertiesAsync(int recipesCount)
        {
            throw new System.NotImplementedException();
        }
    }
}
