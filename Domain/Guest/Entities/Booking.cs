using Domain.Enums;
using Domain.Room.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = Domain.Enums.Action;

namespace Domain.Guest.Entities
{
    public class Booking
    {

        public Booking()
        {
            Status = Status.Created;
        }
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Room.Entities.Room Room { get; set; }
        public Domain.Entities.Guest Guest { get; set; }
        public DateTime PlaceAt { get; set; }
        private Status Status { get; set; }

        public Status CurrentStatus { get { return Status; } }

        public void ChangState(Action action)
        {
            Status = (Status, action) switch
            {
                (Status.Created, Action.Pay) => Status.Paid,
                (Status.Created, Action.Cancel) => Status.Canceled,
                (Status.Paid, Action.Finish) => Status.Finished,
                (Status.Paid, Action.Refound) => Status.Refounded,
                (Status.Canceled, Action.Reopen) => Status.Created,
                _ => Status
            };
        }
    }
}
