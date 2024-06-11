using System;
namespace Design_Patterns.Creational.FactoryPattern
{
    // Product interface
    interface IPaymentGatewayClient
    {
        void ProcessPayment(decimal amount);
    }

    // Concrete products
    class PayPalClient : IPaymentGatewayClient
    {
        public void ProcessPayment(decimal amount)
        {
            // Process payment using PayPal API
        }
    }

    class StripeClient : IPaymentGatewayClient
    {
        public void ProcessPayment(decimal amount)
        {
            // Process payment using Stripe API
        }
    }

    class AuthorizeDotNetClient : IPaymentGatewayClient
    {
        public void ProcessPayment(decimal amount)
        {
            // Process payment using Authorize.Net API
        }
    }

    // Factory interface
    interface IPaymentGatewayFactory
    {
        IPaymentGatewayClient CreatePaymentGatewayClient(PaymentGatewayType type);
    }

    // Concrete factory
    class PaymentGatewayFactory : IPaymentGatewayFactory
    {
        public IPaymentGatewayClient CreatePaymentGatewayClient(PaymentGatewayType type)
        {
            switch (type)
            {
                case PaymentGatewayType.PayPal:
                    return new PayPalClient();
                case PaymentGatewayType.Stripe:
                    return new StripeClient();
                case PaymentGatewayType.AuthorizeDotNet:
                    return new AuthorizeDotNetClient();
                default:
                    throw new NotSupportedException($"Payment gateway type '{type}' is not supported.");
            }
        }
    }

    enum PaymentGatewayType
    {
        PayPal,
        Stripe,
        AuthorizeDotNet
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        IPaymentGatewayFactory paymentGatewayFactory = new PaymentGatewayFactory();

    //        IPaymentGatewayClient paypalClient = paymentGatewayFactory.CreatePaymentGatewayClient(PaymentGatewayType.PayPal);
    //        paypalClient.ProcessPayment(100.0m);

    //        IPaymentGatewayClient stripeClient = paymentGatewayFactory.CreatePaymentGatewayClient(PaymentGatewayType.Stripe);
    //        stripeClient.ProcessPayment(150.0m);
    //    }
    //}

}

