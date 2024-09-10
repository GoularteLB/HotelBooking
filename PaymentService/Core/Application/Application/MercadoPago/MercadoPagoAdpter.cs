using Application.MercadoPago.Exceptions;
using Application.Payment;
using Application.Payment.DTO;
using Application.Payment.Ports;
using Application.Payment.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.MercadoPago
{
    public class MercadoPagoAdpter : IPaymentProcesor
    {
        public Task<PaymentResponse> CapturePayment(string paymentIntention)
        {
            if (string.IsNullOrWhiteSpace(paymentIntention))
            {
                throw new InvalidPaymentIntentionalException();
            }
            paymentIntention += "Sucess";

            var dto = new PaymentStateDto
            {
                CreatedDate = DateTime.Now,
                Message = $"Success Pay{paymentIntention}",
                PaymentId = "123",
                Status = Status.Success

            };
            var response = new PaymentResponse
            {
                Data = dto,
                Success = true,
                Message = "Payment Successfully process"
            };
            return Task.FromResult(response);
        }
       

        public Task<PaymentResponse> PayBancTransfer(string PaymentIntention)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentResponse> PayWithACreditCard(string PaymentIntention)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(PaymentIntention))
                {
                    throw new InvalidPaymentIntentionalException();
                }

                PaymentIntention += "/Success";

                var dto = new PaymentStateDto
                {
                    CreatedDate = DateTime.Now,
                    Message = $"Success Pay{PaymentIntention}",
                    PaymentId = "123",
                    Status = Status.Success
                };

                var response = new PaymentResponse
                {
                    Data = dto,
                    Success = true,
                    Message = "Payment Successfully processed"
                };

                return Task.FromResult(response);
            }
            catch (InvalidPaymentIntentionalException)
            {
                var result = new PaymentResponse
                {
                    Success = false,
                    ErrorCodes = Responses.ErrorCodes.PAYMENT_INVALIDPAYMENT_INTENTION
                };
                return Task.FromResult(result);
            }
        }

        public Task<PaymentResponse> PayWithADebitCard(string PaymentIntention)
        {
            throw new NotImplementedException();
        }
    }
}
