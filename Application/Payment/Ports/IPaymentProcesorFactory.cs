using Application.Booking.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payment.Ports
{
    public interface IPaymentProcesorFactory
    {
        IPaymentProcesor GetPaymentProcesor(SuportPaymentProviders selectPaymentProviders);
    }
}
