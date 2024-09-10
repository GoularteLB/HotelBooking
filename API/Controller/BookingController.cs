using Application.Booking;
using Application.Booking.DTO;
using Application.Booking.Ports;
using Application.Payment.Responses;
using Application.Responses;
using Azure.Core;
using Domain.Booking.DTO;
using Domain.Guest.Entities;
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
        [Route("{booking.Id}/Pay")]
        public async Task<ActionResult<PaymentResponse>> Pay(
            PaymentRequestDto paymentRequestDto,
            int bookingId)
        {
            paymentRequestDto.BookingId = bookingId;
            var resp = await _bookingManager.PayForBooking(paymentRequestDto);

            if(resp.Success) return Ok(resp.Data);

            return BadRequest(resp);
        }

        [HttpPost]
        public async Task<ActionResult<BookingDto>> Post(BookingDto booking)
        {
            var result = await _bookingManager.CreateBooking(booking);

            if (result.Success) return Created("", result.Data);

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
