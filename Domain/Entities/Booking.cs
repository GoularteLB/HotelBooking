using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = Domain.Enums.Action;

namespace Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime Start {get; set;}
        public DateTime End {get; set;}
        public DateTime PlaceAt {get; set;}
        private Status Status { get; set;}

        public Status CurrentStatus { get{ return this.Status; } }

        public void ChangState(Action action)
        {
            this.Status = (this.Status, action) switch
            {
                (Status.Created, Action.Pay) => Status.Paid,
                (Status.Created, Action.Cancel) => Status.Canceled,
                (Status.Paid, Action.Finish) => Status.Finished,
                (Status.Paid, Action.Refound) => Status.Refounded,
                (Status.Created, Action.Reopen) => Status.Created,
                _ => this.Status
            };
        }
    }
}
