using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.DTO
{
    public enum SuportPaymentProviders
    {
        PayPal = 0,
        Strike = 1,
        PagSeguro = 2,
        MercadoPago = 3,

    }
    public enum SuportPaymentMethods
    {
        DebitCard = 0,
        CreditCard = 1,
        BankTransfer = 2,
    }
    public class PaymentRequestDto
    {
        public int BookingId { get; set; }
        public string PaymentIntention { get; set; }
        public SuportPaymentProviders SelectedPaymentProviders { get; set; }
        public SuportPaymentMethods SelectedPaymentMethods { get; set; }
    }
}
