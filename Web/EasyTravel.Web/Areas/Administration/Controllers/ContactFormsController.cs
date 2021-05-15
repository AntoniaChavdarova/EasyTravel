namespace EasyTravel.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EasyTravel.Data;
    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
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

        // GET: Administration/ContactForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactForm =  this.contactsRepository.All().FirstOrDefault(x => x.Id == id);
            if (contactForm == null)
            {
                return this.NotFound();
            }

            this.ViewData["UserId"] = new SelectList(this.contactsRepository.All(), "Id", "Id", contactForm.UserId);
            return View(contactForm);
        }

        // POST: Administration/ContactForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,FullName,Email,Title,Content,Id,CreatedOn,ModifiedOn")] ContactForm contactForm)
        {
            if (id != contactForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.contactsRepository.Update(contactForm);
                    await this.contactsRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactFormExists(contactForm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(this.contactsRepository.All(), "Id", "Id", contactForm.UserId);
            return View(contactForm);
        }

        // GET: Administration/ContactForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactForm = await this.contactsRepository.All()
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactForm == null)
            {
                return NotFound();
            }

            return View(contactForm);
        }

        // POST: Administration/ContactForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactForm = this.contactsRepository.All().FirstOrDefault(x => x.Id == id);
            this.contactsRepository.Delete(contactForm);
            await this.contactsRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactFormExists(int id)
        {
            return this.contactsRepository.All().Any(e => e.Id == id);
        }
    }
}
