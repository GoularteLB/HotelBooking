﻿using Application.Booking;
using Application.Booking.DTO;
using Application.Payment.DTO;
using Application.Payment.Ports;
using Application.Payment.Responses;
using Domain.Booking;
using Domain.Ports;
using Domain.Room.Ports;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests
{
    public class BookingManegerTest
    {
        [Test]
        public async Task ShouldPayForBooking()
        {
            var dto = new PaymentRequestDto
            {
                SelectedPaymentProviders = SuportPaymentProviders.MercadoPago,
                SelectedPaymentMethods = SuportPaymentMethods.CreditCard,
                PaymentIntention = ""
            };

            var bookingRepository = new Mock<IBookingRepository>();
            var roomRepository = new Mock<IRoomRepository>();
            var guestRepository = new Mock<IGuestRepository>();
            var paymentProcessorFactory = new Mock<IPaymentProcesorFactory>();
            var paymentProcessor = new Mock<IPaymentProcesor>();

            var responseDto = new PaymentStateDto
            {
                CreatedDate = DateTime.Now,
                Message = $"Successfully paid {dto.PaymentIntention}",
                PaymentId = "123",
                Status = Status.Success
            };

            var response = new PaymentResponse
            {
                Data = responseDto,
                Success = true,
                Message = "Payment successfully processed"
            };

            paymentProcessor.
               Setup(x => x.CapturePayment(dto.PaymentIntention))
               .Returns(Task.FromResult(response));

            paymentProcessorFactory
             .Setup(x => x.GetPaymentProcesor(dto.SelectedPaymentProviders))
             .Returns(paymentProcessor.Object);

            var bookingManager = new BookingManager(
               bookingRepository.Object,
               (IGuestRepository)roomRepository.Object,
               (IRoomRepository)guestRepository.Object,
               paymentProcessorFactory.Object
               );

            var res = await bookingManager.PayForBooking(dto);

            Assert.NotNull(res);
            Assert.True(res.Success);
            Assert.AreEqual(res.Message, "Payment successfully processed");

        }
    }
}
