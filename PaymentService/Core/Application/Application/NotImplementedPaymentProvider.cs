using Application.Payment.Ports;
using Application.Payment.Responses;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application
{
    public class NotImplementedPaymentProvider : IPaymentProcesor
    {
        public Task<PaymentResponse> CapturePayment(string paymentIntention)
        {
            var paymentResponse = new PaymentResponse()
            {
                Success = false,
                ErrorCodes = ErrorCodes.PAYMENT_PROVIDER_NOT_IMPLEMENTED,
                Message = "The select payment provider is not avalible at this moment"
            };
            return Task.FromResult(paymentResponse);
        }
    }
}
