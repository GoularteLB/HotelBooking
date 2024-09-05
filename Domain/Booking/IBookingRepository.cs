using Domain.Guest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Booking
{
    public interface IBookingRepository
    {
        Task<Guest.Entities.Booking> Get(int id);
        Task<Guest.Entities.Booking> CreateBooking(Guest.Entities.Booking booking);
    }
}
