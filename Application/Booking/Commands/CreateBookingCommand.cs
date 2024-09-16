using Domain.Booking.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.Commands
{
    public class CreateBookingCommand : IRequest<BookingResponse>
    {
        public BookingDto bookingDto {  get; set; }
    }
}
