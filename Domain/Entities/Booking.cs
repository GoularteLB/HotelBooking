using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
