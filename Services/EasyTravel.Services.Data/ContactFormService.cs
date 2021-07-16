namespace EasyTravel.Services.Data
{
    using System.Threading.Tasks;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Web.ViewModels.ContactForms;

    public class ContactFormService : IContactFormService
    {
        private readonly IRepository<ContactForm> contactRepository;

        public ContactFormService(IRepository<ContactForm> contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task MakeContactFormAsync(ContactFormViewModel model, string userId)
        {
            var contactFormEntry = new ContactForm
            {
                UserId = userId,
                FullName = model.FullName,
                Email = model.Email,
                Title = model.Title,
                Content = model.Content,
            };

            await this.contactRepository.AddAsync(contactFormEntry);
            await this.contactRepository.SaveChangesAsync();
        }
    }
}
