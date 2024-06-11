using System;
namespace Design_Patterns.Behavioral.Strategy
{
	//parent child relation ship
	//children wants to override their parent method and those overriden methods has same funcitonality results in code duplication
    //method as a class

	public class Payment
	{
		public virtual void ProcessPayment() { Console.WriteLine("cash payment"); }
	}

	public class DebitCardPayment : Payment
	{
		public override void ProcessPayment() => Console.WriteLine("DebitCard payemnt");
		
	}

    public class PhonePePayment : Payment
    {
        public override void ProcessPayment() => Console.WriteLine("UPI payemnt");

    }

    public class GPayPayment : Payment
    {
        public override void ProcessPayment() => Console.WriteLine("UPI payemnt");
        
    }



    //methods as a class
	public interface PaymentStrategy
	{
		void ProcessPayment();
	}

    public class UPIPaymentStartegy : PaymentStrategy
    {
        public void ProcessPayment() => Console.WriteLine("UPI payemnt");

    }

    public class DebitCardPaymentStartegy : PaymentStrategy
    {
        public void ProcessPayment() => Console.WriteLine("DebitCard payemnt");

    }
    //parent; has a compositon; composition over inheritance
    public class ModernPayment
    {
        PaymentStrategy paymentStrategy;
        public ModernPayment(PaymentStrategy paymentStrategy)
        {
            this.paymentStrategy = paymentStrategy;
        }

        public void ProcessPayment()
        {
            this.paymentStrategy.ProcessPayment();
        }

    }

    public class DebitCardModernPayment : ModernPayment
    {
        public DebitCardModernPayment():base(new DebitCardPaymentStartegy())
        {

        }

    }

    public class PhonePeModernPayment : ModernPayment
    {
        public PhonePeModernPayment() : base(new UPIPaymentStartegy())
        {

            
        }
    }

    public class GPayModernPayment : ModernPayment
    {
        public GPayModernPayment() : base(new UPIPaymentStartegy())
        {

        }
    }

    public class TestClass
    {
        public void TestMethod()
        {
            ModernPayment payment = new PhonePeModernPayment();
            payment.ProcessPayment();
        }
        
    }







}

