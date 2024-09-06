using Application.Responses;
using Domain.Booking.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking
{
    public class BookingResponse : Response
    {
        public BookingDto Data;
    }
}
