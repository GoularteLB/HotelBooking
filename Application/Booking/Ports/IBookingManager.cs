using Application.Booking.DTO;
using Application.Payment.Responses;
using Domain.Booking.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.Ports
{
    public interface IBookingManager
    {
        Task<BookingResponse> CreateBooking(BookingDto booking);
        Task<PaymentResponse> PayForBooking(PaymentRequestDto paymentRequestDto);
        Task<BookingDto> GetBooking(int id);
    }
}
