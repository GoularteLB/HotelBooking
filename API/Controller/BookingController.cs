using Application.Booking;
using Application.Booking.Commands;
using Application.Booking.DTO;
using Application.Booking.Ports;
using Application.Booking.Queries;
using Application.Payment.Responses;
using Application.Responses;
using Azure.Core;
using Data.Booking;
using Domain.Booking;
using Domain.Booking.DTO;
using Domain.Guest.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingManager _bookingManager;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMediator _mediator;

        public BookingController(IBookingManager bookingManager,
            ILogger<BookingController> logger,
            IMediator mediator, IBookingRepository bookingRepository)
        {
            _logger = logger;
            _bookingManager = bookingManager;
            _bookingRepository = bookingRepository;
        }
        [HttpPost]
        [Route("{bookingId}/Pay")]
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
        public async Task<ActionResult<BookingResponse>> Post(BookingDto booking)
        {

            var command = new CreateBookingCommand
            {
                bookingDto = booking
            };
            var result = await _mediator.Send(command);

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
        [HttpGet]
        public async Task<ActionResult<BookingDto>> Get(int id)
        {
            var query = new GetBookingQuery
            {
                Id = id
            };

            var res = await _mediator.Send(query);

            if (res.Success) return Created("", res.Data);

            _logger.LogError("Could not process the request", res);
            return BadRequest(res);
        }
    }
}
