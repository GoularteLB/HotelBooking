using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.Queries
{
    public class GetBookingQuery : IRequest<BookingResponse>
    {
        public int Id { get; set; }
    }
}
