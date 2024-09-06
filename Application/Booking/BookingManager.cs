using Application.Booking.Ports;
using Application.Responses;
using Domain.Booking;
using Domain.Booking.DTO;
using Domain.Booking.Exceptions;
using Domain.Guest.Entities;
using Domain.Ports;
using Domain.Room.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IRoomRepository _roomRepository;
        public BookingManager(IBookingRepository bookingRepository,
                              IGuestRepository guestRepository,
                              IRoomRepository roomRepository) 
        {
            _bookingRepository = bookingRepository;
            _guestRepository = guestRepository;
            _roomRepository = roomRepository;
        }

        public async Task<BookingResponse> CreateBooking(BookingDto bookingDto)
        {
            try
            {
                var booking = BookingDto.MapToEntity(bookingDto);
                booking.Guest = await _guestRepository.Get(bookingDto.GuestId);
                booking.Room = await _roomRepository.GetAgregate(bookingDto.RoomId);

                await booking.Save(_bookingRepository);

                bookingDto.Id = bookingDto.Id;
                return new BookingResponse
                {
                    Sucess = true,
                    Data = bookingDto,
                };
            }
            catch (PlacedIsRequiredInformationException)
            {
                return new BookingResponse
                {
                    Sucess = false,
                    ErrorCodes = ErrorCodes.BOOKING_MISSING_REQUIRED_INFORMATION,
                    Message = "PlacedAt is required information"
                };
            }
            catch (StartDateTimeIsRequiredException)
            {
                return new BookingResponse
                {
                    Sucess = false,
                    ErrorCodes = ErrorCodes.BOOKING_MISSING_REQUIRED_INFORMATION,
                    Message = "Start is required information"
                };
            }
            catch (RoomIsRequiredException)
            {
                return new BookingResponse
                {
                    Sucess = false,
                    ErrorCodes = ErrorCodes.BOOKING_MISSING_REQUIRED_INFORMATION,
                    Message = "Room is required information"
                };
            }
            catch (GuestIsRequiredException)
            {
                return new BookingResponse
                {
                    Sucess = false,
                    ErrorCodes = ErrorCodes.BOOKING_MISSING_REQUIRED_INFORMATION,
                    Message = "Guest is required information"
                };
            }
            catch (Exception)
            {
                return new BookingResponse
                {
                    Sucess = false,
                    ErrorCodes = ErrorCodes.BOOKING_COULD_NOT_STORE_DATA,
                };
            }
        }

        public Task<BookingDto> GetBooking(int id)
        {
            throw new NotImplementedException();
        }
    }
}
