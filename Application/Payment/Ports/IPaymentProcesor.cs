using Application.Payment.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payment.Ports
{
    public interface IPaymentProcessor
    {
        Task<PaymentResponse> CapturePayment(string paymentIntention);
    }
}
