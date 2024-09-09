using Application.Payment.DTO;
using Application.Payment.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payment
{
    public interface IMercadoPagoPaymentService
    {
        Task<PaymentResponse> PayWithACreditCard(string PaymentIntention);
        Task<PaymentResponse> PayWithADebitCard(string PaymentIntention);
        Task<PaymentResponse> PayBancTransfer(string PaymentIntention);
    }
}
