namespace EasyTravel.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EasyTravel.Data.Common.Repositories;
    using EasyTravel.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class BookingsController : Controller
    {
        private readonly IDeletableEntityRepository<Booking> bookingsRepository;
        private readonly IDeletableEntityRepository<Property> propertiesRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public BookingsController(
            IDeletableEntityRepository<Booking> bookingsRepository,
            IDeletableEntityRepository<Property> propertiesRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.bookingsRepository = bookingsRepository;
            this.propertiesRepository = propertiesRepository;
            this.usersRepository = usersRepository;
        }

        // GET: Administration/Bookings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.bookingsRepository.All().Include(b => b.Property).Include(b => b.User);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var booking = this.bookingsRepository.All().FirstOrDefault(x => x.Id == id);
            if (booking == null)
            {
                return this.NotFound();
            }

            this.ViewData["PropertyId"] = new SelectList(this.propertiesRepository.All(), "Id", "Address", booking.PropertyId);
            this.ViewData["UserId"] = new SelectList(this.usersRepository.All(), "Id", "Id", booking.UserId);
            return this.View(booking);
        }

        // POST: Administration/Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PeopleCount,CheckIn,CheckOut,UserId,PropertyId,Confirmed,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Booking booking)
        {
            if (id != booking.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                   this.bookingsRepository.Update(booking);
                   await this.bookingsRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.BookingExists(booking.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["PropertyId"] = new SelectList(this.propertiesRepository.All(), "Id", "Address", booking.PropertyId);
            this.ViewData["UserId"] = new SelectList(this.usersRepository.All(), "Id", "Id", booking.UserId);
            return this.View(booking);
        }

        // GET: Administration/Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var booking = await this.bookingsRepository.All()
                .Include(b => b.Property)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return this.NotFound();
            }

            return this.View(booking);
        }

        // POST: Administration/Bookings/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = this.bookingsRepository.All().FirstOrDefault(x => x.Id == id);
            this.bookingsRepository.Delete(booking);
            await this.bookingsRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool BookingExists(int id)
        {
            return this.bookingsRepository.All().Any(e => e.Id == id);
        }
    }
}
