using Application.Booking.DTO;
using Application.MercadoPago;
using Application.Payment.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application
{
    public class PaymentProcesorFactory: IPaymentProcesorFactory
    {
        public IPaymentProcesor GetPaymentProcesor(SuportPaymentProviders selectPaymentProviders)
        {
            switch (selectPaymentProviders)
            {
                case SuportPaymentProviders.MercadoPago:
                return new MercadoPagoAdpter();

                //The Operation Result Pattern — A Simple Guide
                default: return new NotImplementedPaymentProvider(); 
            }
        }
    }
}
