using Application.MercadoPago.Exceptions;
using Application.Payment;
using Application.Payment.DTO;
using Application.Payment.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MercadoPago
{
    public class MercadoPagoAdpter : IMercadoPagoPaymentService
    {
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

                PaymentIntention += "/Sucess";

                var dto = new PaymentStateDto
                {
                    CreditDate = DateTime.Now,
                    Message = $"Sucess Pay{PaymentIntention}",
                    PaymentId = "123",
                    Status = Status.Sucess
                };

                var response = new PaymentResponse
                {
                    Data = dto,
                    Sucess = true,
                    Message = "Payment sucessefully processed"
                };

                return Task.FromResult(response);
            }
            catch (InvalidPaymentIntentionalException)
            {
                var result = new PaymentResponse
                {
                    Sucess = false,
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
