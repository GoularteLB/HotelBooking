using Application.Guest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guest.Requests
{
    public class CreateGuestRequest
    {
        public GuestDTO Data { get; set; }
    }
}
