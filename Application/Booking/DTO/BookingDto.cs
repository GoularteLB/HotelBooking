using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Room.Dtos;
using Application.Guest.DTO;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Booking.DTO
{
    public class BookingDto
    {
        public BookingDto()
        {
            this.PlaceAt = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public DateTime PlaceAt { get; set; }
        private Status Status { get; set; }

        public static Guest.Entities.Booking MapToEntity(BookingDto bookingdto)
        {
            return new Guest.Entities.Booking
            {
                Id = bookingdto.Id,
                Start = bookingdto.Start,
                Guest = new Entities.Guest() { Id = bookingdto.Id},
                Room = new Room.Entities.Room() { Id = bookingdto.Id},
                End = bookingdto.End
            };
        } 
    }
}
