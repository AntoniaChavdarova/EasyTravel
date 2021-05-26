namespace EasyTravel.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Data;
    using EasyTravel.Web.ViewModels.ContactForms;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ContactsController : BaseController
    {
        private readonly IContactFormService contactFormService;

        public ContactsController(IContactFormService contactFormService)
        {
            this.contactFormService = contactFormService;
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

            try
            {
                await this.contactFormService.MakeContactFormAsync(model, userId);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(model);
            }

            return this.RedirectToAction("ThankYou");
        }

        [Authorize]
        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
