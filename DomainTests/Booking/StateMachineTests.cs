using Domain.Entities;
using Domain.Enums;
using Action = Domain.Enums.Action;


namespace DomainTests.Bookings
{
    public class StateMachineTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ShouldAwaysStarWithCreatredStatus() 
        {
            var booking = new Booking();
            Assert.AreEqual(booking.CurrentStatus, Status.Created);
        }

        [Test]
        public void ShouldSetStatusToPaidWhenPayingForBookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangState(Action.Pay);
            Assert.AreEqual(booking.CurrentStatus, Status.Paid);
        }
        
        [Test]
        public void ShouldSetStatusToPaidWhenCancelForBookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangState(Action.Cancel);
            Assert.AreEqual(booking.CurrentStatus, Status.Canceled);
        }
        
        [Test]
        public void ShouldSetStatusToPaidWhenFinishForBookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangState(Action.Pay);
            booking.ChangState(Action.Finish);
            Assert.AreEqual(booking.CurrentStatus, Status.Finished);
        }
        
        [Test]
        public void ShouldSetStatusToPaidWhenRefoundForBookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangState(Action.Pay);
            booking.ChangState(Action.Refound);
            Assert.AreEqual(booking.CurrentStatus, Status.Refounded);
        } 
        
        [Test]
        public void ShouldSetStatusToPaidWhenReopenForBookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangState(Action.Cancel);
            booking.ChangState(Action.Reopen);
            Assert.AreEqual(booking.CurrentStatus, Status.Created);  
        }
        
        [Test]
        public void ShouldNotChangeStatusWhenRefoundABookingWithCreateStatus()
        {
            var booking = new Booking();

            booking.ChangState(Action.Refound);
            Assert.AreEqual(booking.CurrentStatus, Status.Created);  
        }
        
        [Test]
        public void ShoudNotChangeStatusWhenRefoundABookingWithCreateStatus()
        {
            var booking = new Booking();

            booking.ChangState(Action.Pay);
            booking.ChangState(Action.Finish);
            booking.ChangState(Action.Refound);
            Assert.AreEqual(booking.CurrentStatus, Status.Finished);  
        }
    }
}
