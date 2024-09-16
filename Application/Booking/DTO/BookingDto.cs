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

        public static Guest.Entities.Booking MapToEntity(BookingDto bookingDto)
        {
            return new Guest.Entities.Booking
            {
                Id = bookingDto.Id,
                Start = bookingDto.Start,
                Guest = new Entities.Guest { Id = bookingDto.GuestId },
                Room = new Room.Entities.Room { Id = bookingDto.RoomId },
                End = bookingDto.End,
                PlaceAt = bookingDto.PlaceAt,
            };
        }
        public static BookingDto MapToDto(Guest.Entities.Booking booking)
        {
            return new BookingDto
            {
                Id = booking.Id,
                End = booking.End,
                GuestId = booking.Guest.Id,
                PlaceAt = booking.PlaceAt,
                RoomId = booking.Room.Id,
                Status = booking.Status,
                Start = booking.Start,
            };
        }
    }
}

