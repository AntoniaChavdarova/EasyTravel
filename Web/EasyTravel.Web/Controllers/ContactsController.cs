namespace EasyTravel.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Web.ViewModels.ContactForms;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ContactsController : BaseController
    {
        private readonly IRepository<ContactForm> contactsRepository;

        public ContactsController(IRepository<ContactForm> contactsRepository)
        {
            this.contactsRepository = contactsRepository;
        }

        [Authorize]
        public IActionResult Contact()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Contact(ContactFormViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var contactFormEntry = new ContactForm
            {
                UserId = userId,
                FullName = model.FullName,
                Email = model.Email,
                Title = model.Title,
                Content = model.Content,

            };

            await this.contactsRepository.AddAsync(contactFormEntry);
            await this.contactsRepository.SaveChangesAsync();

            return this.RedirectToAction("ThankYou");
        }

        [Authorize]
        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
