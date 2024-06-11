using System;
namespace Design_Patterns.Behavioral.TemplateMethod
{
    public class Payment
    {
        public Payment()
        {
        }
    }
    /*When you want all the classes to follow the specific steps
	 *to process the task but also 
	 *need to provide the flexibility that each class can have their own logic in 
	 *specific steps
	 
	 
	 */

    public abstract class PaymentFlow
    {
        public abstract void ValidateRequest();
        public abstract void DebitAmount();
        public abstract void CalculatePlatFormFee();
        public abstract void CreditAmount();



        public void SendMoney()
        {
            ValidateRequest();
            DebitAmount();
            CalculatePlatFormFee();
            CreditAmount();

        }


    }


    public class PaymentToFriend : PaymentFlow
    {
        public override void ValidateRequest()
        {
            Console.Write("request validation");
        }
        public override void CalculatePlatFormFee()
        {
            Console.Write("0 platformfee");
        }

        public override void DebitAmount()
        {
            Console.Write("debitamount");
        }
        public override void CreditAmount()
        {
            Console.Write("credit amount");
        }

    }

    public class PaymentToMerchant : PaymentFlow
    {
        public override void ValidateRequest()
        {
            Console.Write("request validation");
        }
        public override void CalculatePlatFormFee()
        {
            Console.Write("5% platformfee");
        }

        public override void DebitAmount()
        {
            Console.Write("debitamount");
        }
        public override void CreditAmount()
        {
            Console.Write("credit amount");
        }
    }


    public class TestClass
    {
        public void TestMethod()
        {
            PaymentFlow flow = new PaymentToFriend();
            flow.SendMoney();
        }
    }
}

