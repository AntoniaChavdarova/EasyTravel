namespace EasyTravel.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using EasyTravel.Services;
    using EasyTravel.Services.Data;
    using EasyTravel.Web.ViewModels.Bookings;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class BookingsController : BaseController
    {
        private readonly IBookingsSerivece bookingsService;
        private readonly IDateTimeParserService dateTimeParser;
        private readonly IPropertiesService propertiesService;

        public BookingsController(
            IBookingsSerivece bookingsService,
            IDateTimeParserService dateTimeParser,
            IPropertiesService propertiesService)
        {
            this.bookingsService = bookingsService;
            this.dateTimeParser = dateTimeParser;
            this.propertiesService = propertiesService;
        }

        [Authorize]
        public IActionResult CreateBooking(int id)
        {
            var user = this.User.FindFirst(ClaimTypes.Email).Value;
            var name = this.propertiesService.GetNameByPropertyId(id);

            var viewModel = new BookingInputModel
            {
                PropertyId = id,
                UserEmail = user,
                PropName = name,
            };

            return this.View(viewModel);

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingInputModel viewModel, int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            var dateCheckIn = this.dateTimeParser.ConvertStrings(viewModel.CheckIn);
            var dateCheckOut = this.dateTimeParser.ConvertStrings(viewModel.CheckOut);

            try
            {
                await this.bookingsService.MakeBookingAsync(userId, id, dateCheckIn, dateCheckOut);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(viewModel);
            }

            return this.RedirectToAction(nameof(this.AllBookings));
        }

        public async Task<IActionResult> AllBookings()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var viewModel = new BookingsListViewModel
            {
                MyBookings = await this.bookingsService.MyBookings<BookingViewModel>(userId),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> CancelBooking(int id)
        {
            var viewModel = await this.bookingsService.GetByIdAsync<BookingViewModel>(id);

            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await this.bookingsService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.AllBookings));
        }
    }
}