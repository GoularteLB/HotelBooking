using Application.Booking.Commands;
using Domain.Booking;
using Domain.Entities;
using Domain.Guest.Entities;
using Domain.Ports;
using Domain.Room.Entities;
using Domain.Room.Ports;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests
{
    public class CreateBookingCommandHandlerTests
    {
        private CreateBookingCommandHandler GetCommand(
            Mock<IRoomRepository> roomRepository = null,
            Mock<IGuestRepository> guestRepository = null,
            Mock<IBookingRepository> bookingRepository = null
            )
        {
            var _bookingRepository = bookingRepository ?? new Mock<IBookingRepository>();
            var _guestRepository = guestRepository ?? new Mock<IGuestRepository>();
            var _roomRepository = roomRepository ?? new Mock<IRoomRepository>();

            return new CreateBookingCommandHandler(
                    _bookingRepository.Object,
                    _roomRepository.Object,
                     _guestRepository.Object
                );
        }
        [Test]
        public async Task Should_Not_CreateBooking_If_Room_Is_Missing()
        {
            var command = new CreateBookingCommand
            {
                BookingDto = new Domain.Booking.DTO.BookingDto
                {
                    GuestId = 1,
                    Start = DateTime.UtcNow,
                    End = DateTime.UtcNow.AddDays(2)
                }

            };
            var fakeGuest = new Guest
            {
                Id = command.BookingDto.GuestId,
                DocumentId = new Domain.ValueObjects.PersonId
                {
                    DocumentType = Domain.Enums.DocumentType.Passport,
                    IdNumber = "abc1234"
                },
                Email = "test@.com",
                Name = " Guest",
                Surname = " Surname"
            };
            var guestRepository = new Mock<IGuestRepository>();
            guestRepository.Setup(x => x.Get(command.BookingDto.GuestId))
                .Returns(Task.FromResult(fakeGuest));
            var fakeRoom = new Room
            {
                Id = command.BookingDto.RoomId,
                InMaintenance = false,
                Price = new Domain.ValueObjects.Price
                {
                    currency = Domain.Enums.AcceptedCurrencies.Dollar,
                    Value = 100
                },
                Name = "Fake Room 01",
                Level = 1,
            };
            var fakeBooking = new Booking
            {
                Id = 1
            };

            var bookingRepository = new Mock<IBookingRepository>();
            bookingRepository.Setup(x => x.CreateBooking(It.IsAny<Booking>()))
                .Returns(Task.FromResult(fakeBooking));

            var handler = GetCommand(null, guestRepository, bookingRepository);
            var resp = await handler.Handle(command, CancellationToken.None);
            Assert.NotNull(resp);
            Assert.False(resp.Success);
            Assert.AreEqual(resp.ErrorCodes, Application.Responses.ErrorCodes.BOOKING_MISSING_REQUIRED_INFORMATION);
            Assert.AreEqual(resp.Message, "Room is a required information");

        }
    }
}
