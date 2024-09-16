using Domain.Booking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Booking
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelDbContext _hotelDbContext;
        public BookingRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }
        public async Task<Domain.Guest.Entities.Booking> CreateBooking(Domain.Guest.Entities.Booking booking)
        {
            _hotelDbContext.Bookings.Add(booking);
            await _hotelDbContext.SaveChangesAsync();
            return booking;
        }

        public Task<Domain.Guest.Entities.Booking> Get(int id)
        {
            return _hotelDbContext.Bookings.Include(b => b.Guest).Include(b => b.Room).Where(x => x.Id == id).FirstAsync();
        }
    }
}
