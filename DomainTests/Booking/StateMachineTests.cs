using Domain.Enums;
using Domain.Guest.Entities;
using Domain.Enums;

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
            Assert.AreEqual(booking.Status, Status.Created);
        }
        
        [Test]
        public void ShouldSetStatusToPaidWhenPayingForABookingCreateStatus()
        {
            var booking = new Booking();

            booking.ChangState(Domain.Enums.Action.Pay);
            Assert.AreEqual(booking.Status, Status.Paid);
        }
        
        [Test]
        public void ShouldSetStatusToCanceledWhenCancelingABookingCreateStatus()
        {
            var booking = new Booking();

            booking.ChangState(Domain.Enums.Action.Cancel);
            Assert.AreEqual(booking.Status, Status.Canceled);
        }
        
        [Test]
        public void ShouldSetStatusToFinishWhenFinishingABookingCreateStatus()
        {
            var booking = new Booking();

            booking.ChangState(Domain.Enums.Action.Pay);
            booking.ChangState(Domain.Enums.Action.Finish);
            Assert.AreEqual(booking.Status, Status.Finished);
        }
        
        [Test]
        public void ShouldSetStatusToReopenWhenReopeningABooking()
        {
            var booking = new Booking();

            booking.ChangState(Domain.Enums.Action.Cancel);
            booking.ChangState(Domain.Enums.Action.Reopen);
            Assert.AreEqual(booking.Status, Status.Created);
        }
        
        [Test]
        public void ShouldNotChangeStatusWhenRefoundABookingCreateState()
        {
            var booking = new Booking();

            booking.ChangState(Domain.Enums.Action.Refound);
            Assert.AreEqual(booking.Status, Status.Created);
        }
    }
}