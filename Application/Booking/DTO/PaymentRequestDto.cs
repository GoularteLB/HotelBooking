using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.DTO
{
    public enum SupportedPaymentProviders
    {
        PayPal = 1,
        Stripe = 2,
        PagSeguro = 3,
        MercadoPago = 4,

    }
    public enum SupportedPaymentMethods
    {
        DebitCard = 1,
        CreditCard = 2,
        BankTransfer = 3,
    }
    public class PaymentRequestDto
    {
        public int BookingId { get; set; }
        public string PaymentIntention { get; set; }
        public SupportedPaymentProviders selectedPaymentProvider { get; set; }
        public SupportedPaymentMethods SelectedPaymentMethod { get; set; }
    }
}
