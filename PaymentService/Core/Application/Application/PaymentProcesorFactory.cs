using Application.Booking.DTO;
using Application.MercadoPago;
using Application.Payment.Ports;
using Payments.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application
{
    public class PaymentProcesorFactory: IPaymentProcessorFactory
    {

        public IPaymentProcessor GetPaymentProcessor(SupportedPaymentProviders selectedPaymentProvider)
        {
            switch (selectedPaymentProvider)
            {
                case SupportedPaymentProviders.MercadoPago:
                    return new MercadoPagoAdapter();

                default: return new NotImplementedPaymentProvider();
            }
        }
    }
}
