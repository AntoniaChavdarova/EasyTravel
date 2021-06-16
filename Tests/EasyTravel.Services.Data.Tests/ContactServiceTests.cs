namespace EasyTravel.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using EasyTravel.Data;
    using EasyTravel.Data.Models;
    using EasyTravel.Data.Repositories;
    using EasyTravel.Services.Mapping;
    using EasyTravel.Web.ViewModels;
    using EasyTravel.Web.ViewModels.ContactForms;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class ContactServiceTests
    {
        public ContactServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public async Task ContactFormShouldSaveContactFormsCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfRepository<ContactForm>(new ApplicationDbContext(options.Options));
            var contactFormService = new ContactFormService(repository);

            await contactFormService.MakeContactFormAsync(new ContactFormViewModel { FullName = "Lia" }, "1");

            Assert.Equal(1, repository.All().Count());
            Assert.Equal("Lia", repository.All().FirstOrDefault().FullName);
        }

    }
}
