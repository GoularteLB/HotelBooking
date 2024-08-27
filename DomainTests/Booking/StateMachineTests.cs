using Domain.Entities;
using Domain.Enums;
using NUnit.Framework;

namespace DomainTests.Bookings
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldAwaysStartCreatedStatus()
        {
            var booking = new Booking();
            Assert.AreEqual(booking.CurrentStatus, Status.Created);
        }
        
        [Test]
        public void ShouldSetStatusToPaidWhenPayingForABookingCreateStatus()
        {
            var booking = new Booking();

            booking.ChangState(Domain.Enums.Action.Pay);
            Assert.AreEqual(booking.CurrentStatus, Status.Paid);
        }
        
        [Test]
        public void ShouldSetStatusToCanceledWhenCancelingABookingCreateStatus()
        {
            var booking = new Booking();

            booking.ChangState(Domain.Enums.Action.Cancel);
            Assert.AreEqual(booking.CurrentStatus, Status.Canceled);
        }
        
        [Test]
        public void ShouldSetStatusToFinishWhenFinishingABookingCreateStatus()
        {
            var booking = new Booking();

            booking.ChangState(Domain.Enums.Action.Pay);
            booking.ChangState(Domain.Enums.Action.Finish);
            Assert.AreEqual(booking.CurrentStatus, Status.Finished);
        }
        
        [Test]
        public void ShouldSetStatusToReopenWhenReopeningABooking()
        {
            var booking = new Booking();

            booking.ChangState(Domain.Enums.Action.Cancel);
            booking.ChangState(Domain.Enums.Action.Reopen);
            Assert.AreEqual(booking.CurrentStatus, Status.Created);
        }
        
        [Test]
        public void ShouldNotChangeStatusWhenRefoundABookingCreateState()
        {
            var booking = new Booking();

            booking.ChangState(Domain.Enums.Action.Refound);
            Assert.AreEqual(booking.CurrentStatus, Status.Created);
        }
    }
}