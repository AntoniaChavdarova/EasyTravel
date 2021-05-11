using AngleSharp;
using EasyTravel.Data.Common.Repositories;
using EasyTravel.Data.Models;
using EasyTravel.Services.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EasyTravel.Services
{
    public class PochivkaBgScraperService : IPochivkaBgScraperService
    {
        private const string BaseUrl = "https://pochivka.bg/apartamenti-a4";

        private readonly IBrowsingContext context;
        private readonly IDeletableEntityRepository<Property> propertiesRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<City> citiesRepository;
        private readonly IRepository<Amenity> amenitiesRepository;
        private readonly IRepository<PropertyAmenity> propAmenitiesRepository;
        private readonly IRepository<Image> imagesRepository;

        public PochivkaBgScraperService(
            IDeletableEntityRepository<Property> propertyRepository,
            IRepository<Amenity> amenitiesRepository,
            IRepository<Image> imagesRepository,
            IDeletableEntityRepository<Category> categoriesRepository,
            IDeletableEntityRepository<City> citiesRepository,
            IRepository<PropertyAmenity> propAmenitiesRepository)
        {
            this.propertiesRepository = propertyRepository;
            this.amenitiesRepository = amenitiesRepository;
            this.imagesRepository = imagesRepository;
            this.categoriesRepository = categoriesRepository;
            this.citiesRepository = citiesRepository;
            this.propAmenitiesRepository = propAmenitiesRepository;

            var config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(config);
        }

        public async Task ImportRecipesAsync(int fromId, int toId)
        {

            var concurrentBag = this.ScrapeProperty(fromId, toId);
           // Console.WriteLine($"Scraped recipes: {concurrentBag.Count}");

            foreach (var prop in concurrentBag)
            {
                var categoryId = await this.GetOrCreateCategoryAsync(prop.CategoryName);
                var cityId = await this.GetOrCreateCityAsync(prop.CityName);

                var newProperty = new Property
                {
                    Name = prop.Name,
                    Description = prop.Description,
                    Capacity = prop.Capacity,
                    PhoneNumber = prop.PhoneNumber,
                    Address = prop.Address,
                    OriginalUrl = prop.OriginalUrl,
                    CategoryId = categoryId,
                    CityId = cityId,
                    PriceSummerr = prop.SummerPrice,
                    PriceWinter = prop.WinterPrice,
                };
                await this.propertiesRepository.AddAsync(newProperty);

                var amenities = prop.Amenities;
 
                foreach (var a in amenities)
                {
                    var amenityId = await this.GetOrCreateAmenitytAsync(a.Trim());

                    var propertyAmenity = new PropertyAmenity
                    {
                       AmenityId = amenityId,
                       Property = newProperty,
                    };
                    await this.propAmenitiesRepository.AddAsync(propertyAmenity);
                    await this.propAmenitiesRepository.SaveChangesAsync();
                }

                var images = prop.Images;

                foreach (var i in images)
                {
                    var image = new Image
                    {
                        RemoteImageUrl = i,
                        Property = newProperty,
                    };
                 await this.imagesRepository.AddAsync(image);
                }     
            }

            await this.propertiesRepository.SaveChangesAsync();
           
        }

        private ConcurrentBag<PropertyDto> ScrapeProperty(int fromId, int toId)
        {

            var concurrentBag = new ConcurrentBag<PropertyDto>();
            Parallel.For(fromId, toId + 1, i =>
            {
                try
                {
                    var property = this.GetProperty(i);
                    concurrentBag.Add(property);
                }
                catch
                {
                    // ignored
                }
            });
            return concurrentBag;
        }

        private PropertyDto GetProperty(int id)
        {
            var url = BaseUrl + $"/{id}";

            var document = this.context
                .OpenAsync(url)
                .GetAwaiter()
                .GetResult();

            if (document.StatusCode == HttpStatusCode.NotFound ||
                document.DocumentElement.OuterHtml.Contains("Тази страница не е намерена"))
            {
                throw new InvalidOperationException();
            }

            var elements = document.QuerySelectorAll(".result-item");
            var links = new List<string>();
           // var links = new ConcurrentBag<string>();

            //Parallel.ForEach(elements, item =>
            //{
            //    var link = item.QuerySelector(".thumb > a ").GetAttribute("href");
            //    links.Add(link);
            //});

            foreach (var item in elements)
            {
                var link = item.QuerySelector(".thumb > a ").GetAttribute("href");
                links.Add(link);
            }

            links.ToList();

           var property1 = new PropertyDto();

              foreach (var l in links)
                {
                    var hhh = "https:" + l;
                    var page = this.context
                   .OpenAsync(hhh)
                   .GetAwaiter()
                   .GetResult();

                    var property = new PropertyDto();

                    property.OriginalUrl = hhh;
                    var category = page.QuerySelector("#breadcrumbs > ul > li:nth-child(2) > a");
                    property.CategoryName = category.TextContent.TrimStart();

                    var titlePage = page.QuerySelector(" .page-title > .pull-left > h1");
                    property.Name = titlePage.TextContent;
                    var phone = page.QuerySelector("#popup_phone > div.content > div.pull-left");
                    property.PhoneNumber = phone.TextContent.TrimStart();
                    var address = page.QuerySelector("#popup_address > div.content");
                    property.Address = address.TextContent.TrimStart();
                    var city = page.QuerySelector("body > div.container > div > div.property-view.vip > div:nth-child(1) > div > div > div > div.sub-title");
                    property.CityName = city.TextContent;
                    var descriptionPage = page.QuerySelector("div.col-4.margin-0.pull-right > div.description");
                    property.Description = descriptionPage.TextContent.TrimStart();
                    var amenities = page.QuerySelectorAll("div.col-4 > div.extras > ul > li")
                       .Select(x => x.TextContent) 
                      .ToList();

                    property.Amenities.AddRange(amenities);

                    var tablewithInfo = page.QuerySelectorAll("#prices > table > tbody > tr > td").Select(x => x.TextContent)
                        .ToList();

                    
                    var count = int.Parse(tablewithInfo[1]);
                    property.SummerPrice = tablewithInfo[3];
                    property.WinterPrice = tablewithInfo[5];
                    property.Capacity = count;

                    var imgElements = page.GetElementsByClassName("gallery-slider");

                    foreach (var img in imgElements)
                    {
                        var image = img.QuerySelectorAll("img");
                        foreach (var one in image)
                        {
                            var linkOfPhoto = one.GetAttribute("content");
                            property.Images.Add(linkOfPhoto);
                        }
                    }

                    property1 = property;
                }
            return property1;

        }

        private async Task<int> GetOrCreateCategoryAsync(string categoryName)
        {
            var category = this.categoriesRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Name == categoryName);

            if (category != null)
            {
                return category.Id;
            }

            category = new Category
            {
                Name = categoryName,
            };

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();

            return category.Id;
        }

        private async Task<int> GetOrCreateCityAsync(string cityName)
        {
            var city = this.citiesRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Name == cityName);

            if (city != null)
            {
                return city.Id;
            }

            city = new City
            {
                Name = cityName,
            };

            await this.citiesRepository.AddAsync(city);
            await this.citiesRepository.SaveChangesAsync();

            return city.Id;
        }

        private async Task<int> GetOrCreateAmenitytAsync(string name)
        {
            var amenity = this.amenitiesRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Name == name);

            if (amenity != null)
            {
                return amenity.Id;
            }

            amenity = new Amenity
            {
                Name = name,
            };

            await this.amenitiesRepository.AddAsync(amenity);
            await this.amenitiesRepository.SaveChangesAsync();

            return amenity.Id;
        }
    }
}
