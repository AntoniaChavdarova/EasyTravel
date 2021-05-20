using EasyTravel.Services;
using EasyTravel.Services.Data;
using EasyTravel.Web.ViewModels.Bookings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EasyTravel.Web.Controllers
{
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

            return this.Redirect("/");
        }
    }
}

