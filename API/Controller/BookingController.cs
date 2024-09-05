using Application.Booking.Ports;
using Domain.Booking.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [ApiController]
    [Route("/Controller")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingManager _bookingManager;
        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
            
        }
        [HttpPost]
        public async Task<ActionResult<BookingDto>> Post(BookingDto booking)
        {
            await _bookingManager.CreateBooking(booking);
        }
    }
}
