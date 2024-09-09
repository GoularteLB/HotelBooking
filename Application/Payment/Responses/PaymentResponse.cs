using Application.Payment.DTO;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payment.Responses
{
    public class PaymentResponse : Response
    {
        public PaymentStateDto Data { get; set; } 
    }
}
