using Application.Booking.DTO;
using Application.Booking.Ports;
using Application.Payment.Ports;
using Application.Payment.Responses;
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
        private readonly IPaymentProcessorFactory _paymentProcessorFactory;
        public BookingManager(IBookingRepository bookingRepository,
            IRoomRepository roomRepository,
            IGuestRepository guestRepository,
            IPaymentProcessorFactory paymentProcessorFactory)
        {
            _bookingRepository = bookingRepository;
            _guestRepository = guestRepository;
            _roomRepository = roomRepository;
            _paymentProcessorFactory = paymentProcessorFactory;
        }

        public async Task<BookingResponse> CreateBooking(BookingDto bookingDto)
        {
            try
            {
                var booking = BookingDto.MapToEntity(bookingDto);
                booking.Guest = await _guestRepository.Get(bookingDto.GuestId);
                booking.Room = await _roomRepository.GetAggregate(bookingDto.RoomId);

                await booking.Save(_bookingRepository);

                bookingDto.Id = bookingDto.Id;
                return new BookingResponse
                {
                    Success = true,
                    Data = bookingDto,
                };
            }
            catch (PlacedIsRequiredInformationException)
            {
                return new BookingResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.BOOKING_MISSING_REQUIRED_INFORMATION,
                    Message = "PlacedAt is required information"
                };
            }
            catch (StartDateTimeIsRequiredException)
            {
                return new BookingResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.BOOKING_MISSING_REQUIRED_INFORMATION,
                    Message = "Start is required information"
                };
            }
            catch (RoomIsRequiredException)
            {
                return new BookingResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.BOOKING_MISSING_REQUIRED_INFORMATION,
                    Message = "Room is required information"
                };
            }
            catch (GuestIsRequiredException)
            {
                return new BookingResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.BOOKING_MISSING_REQUIRED_INFORMATION,
                    Message = "Guest is required information"
                };
            }
            catch (Exception)
            {
                return new BookingResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.BOOKING_COULD_NOT_STORE_DATA,
                };
            }
        }
        public Task<BookingDto> GetBooking(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentResponse> PayForBooking(PaymentRequestDto paymentRequestDto)
        {
            var paymentProcessor = _paymentProcessorFactory.GetPaymentProcessor(paymentRequestDto.selectedPaymentProvider);

            var response = await paymentProcessor.CapturePayment(paymentRequestDto.PaymentIntention);

            if (response.Success)
            {
                return new PaymentResponse
                {
                    Success = true,
                    Data = response.Data,
                    Message = "Payment successfully processed"
                };
            }
            return response;
        }
    }
}
