namespace EasyTravel.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class ContactFormsController : AdministrationController
    {
        private readonly IRepository<ContactForm> contactsRepository;

        public ContactFormsController(IRepository<ContactForm> contactsRepository)
        {
            this.contactsRepository = contactsRepository;
        }

        // GET: Administration/ContactForms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.contactsRepository.All().Include(c => c.User);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/ContactForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var contactForm = await this.contactsRepository.All()
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactForm == null)
            {
                return this.NotFound();
            }

            return this.View(contactForm);
        }

        // GET: Administration/ContactForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var contactForm = await this.contactsRepository.All()
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactForm == null)
            {
                return this.NotFound();
            }

            return this.View(contactForm);
        }

        // POST: Administration/ContactForms/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactForm = this.contactsRepository.All().FirstOrDefault(x => x.Id == id);
            this.contactsRepository.Delete(contactForm);
            await this.contactsRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ContactFormExists(int id)
        {
            return this.contactsRepository.All().Any(e => e.Id == id);
        }
    }
}
