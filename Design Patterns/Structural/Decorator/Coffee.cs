using System;
namespace Design_Patterns.Structural.Decorator
{
    /* 
	 suppose coffe base class
	different types of cofy milk, powder,water,sugar
	what if we want to make with only certain ingredents then we have to make that many subclasses in permutations which
	will return in class explosion so how this is avoided? using decorator pattern
	 eg: Pizaa,coffe,
	 */
    using System;

    // Component interface
    interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    // Concrete component
    class SimpleCoffee : ICoffee
    {
        public string GetDescription()
        {
            return "Simple Coffee";
        }

        public double GetCost()
        {
            return 1.0;
        }
    }

    // Decorator class
    abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee coffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            this.coffee = coffee;
        }

         public abstract string GetDescription();

         public abstract double GetCost();
       
    }

    // Concrete decorators
    class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return $"{coffee.GetDescription()}, Milk";
        }

        public override double GetCost()
        {
            return coffee.GetCost() + 0.5;
        }
    }

    class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return $"{coffee.GetDescription()}, Sugar";
        }

        public override double GetCost()
        {
            return coffee.GetCost() + 0.2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Ordering a simple coffee
            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine($"Description: {coffee.GetDescription()}, Cost: {coffee.GetCost()}");

            // Adding milk to the coffee
            coffee = new MilkDecorator(coffee);
            Console.WriteLine($"Description: {coffee.GetDescription()}, Cost: {coffee.GetCost()}");

            // Adding sugar to the coffee
            coffee = new SugarDecorator(coffee);
            Console.WriteLine($"Description: {coffee.GetDescription()}, Cost: {coffee.GetCost()}");
        }
    }



}

