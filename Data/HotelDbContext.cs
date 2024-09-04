using Microsoft.EntityFrameworkCore;
using Entities = Domain.Entities;
using Data.Rooms;
using Data.Guest;
using Domain.Entities;
using Domain.Room.Entities;
using Domain.Guest.Entities;

namespace Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) {}

        public virtual DbSet<Entities.Guest> Guests { get; set; }
        public virtual DbSet<Domain.Room.Entities.Room> Rooms { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GuestConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
        }
    }
}
