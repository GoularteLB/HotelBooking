using Application.Booking.DTO;
using Application.Booking;
using Application.MercadoPago;
using Application.Payment;
using Application.Payment.Ports;
using Application.Responses;
using NUnit.Framework;
using Payment.Application;
using Application.Payment;
using System.Threading.Tasks;
using Payments.Application;

namespace PaymentService.UnitTests
{
    public class Tests
    {
        [Test]
        public void ShouldReturn_NotImplementedPaymentProvider_WhenAskingForStripeProvider()
        {
            var factory = new PaymentProcesorFactory();

            var provider = factory.GetPaymentProcessor(SupportedPaymentProviders.Stripe);

            Assert.AreEqual(provider.GetType(), typeof(NotImplementedPaymentProvider));
        }

        [Test]
        public void ShouldReturn_MercadoPagoAdapter_Provider()
        {
            var factory = new PaymentProcesorFactory();

            var provider = factory.GetPaymentProcessor(SupportedPaymentProviders.MercadoPago);

            Assert.AreEqual(provider.GetType(), typeof(MercadoPagoAdapter));
        }

        [Test]
        public async Task ShouldReturnFalse_WhenCapturingPaymentFor_NotImplementedPaymentProvider()
        {
            var factory = new PaymentProcesorFactory();

            var provider = factory.GetPaymentProcessor(SupportedPaymentProviders.Stripe);

            var res = await provider.CapturePayment("https://myprovider.com/asdf");

            Assert.False(res.Success);
            Assert.AreEqual(res.ErrorCodes, ErrorCodes.PAYMENT_PROVIDER_NOT_IMPLEMENTED);
            Assert.AreEqual(res.Message, "The selected payment provider is not available at the moment");
        }
    }
}
