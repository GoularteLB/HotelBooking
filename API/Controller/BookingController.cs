using Application.Booking.Ports;
using Application.Responses;
using Azure.Core;
using Domain.Booking.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [ApiController]
    [Route("/Controller")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingManager _bookingManager;
        public BookingController(IBookingManager bookingManager,
            ILogger<BookingController> logger)
        {
            _logger = logger;
            _bookingManager = bookingManager;
            
        }
        [HttpPost]
        public async Task<ActionResult<BookingDto>> Post(BookingDto booking)
        {
            var result = await _bookingManager.CreateBooking(booking);

            if (result.Sucess) return Created("", result.Data);

            else if (result.ErrorCodes == ErrorCodes.BOOKING_MISSING_REQUIRED_INFORMATION)
            {
                return BadRequest(result);
            }
            else if (result.ErrorCodes == ErrorCodes.BOOKING_COULD_NOT_STORE_DATA)
            {
                return BadRequest(result);
            }

            _logger.LogError("Response with unknown ErrorCode Returned", result);
            return BadRequest(500);
        }
    }
}
