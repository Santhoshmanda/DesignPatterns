using System;
namespace Design_Patterns.Structural.Decorator.Pizza
{
	using System;

// Component: Defines the basic interface for Pizza
public abstract class Pizza
{
    public abstract string GetDescription();
    public abstract double GetCost();
}

// Concrete Component: A plain pizza with no toppings
public class PlainPizza : Pizza
{
    public override string GetDescription()
    {
        return "Plain Pizza";
    }

    public override double GetCost()
    {
        return 5.00; // Base price of plain pizza
    }
}

// Decorator: Abstract class for pizza toppings
//if there is any common logic that can be kept here else this class is not required
public abstract class PizzaDecorator : Pizza
{
    protected Pizza _pizza;

    public PizzaDecorator(Pizza pizza)
    {
        _pizza = pizza;
    }

    public override string GetDescription()
    {
        return _pizza.GetDescription();
    }

    public override double GetCost()
    {
        return _pizza.GetCost();
    }
}

// Concrete Decorator 1: Adds cheese to the pizza
public class CheeseDecorator : PizzaDecorator
{
    public CheeseDecorator(Pizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return _pizza.GetDescription() + ", Cheese";
    }

    public override double GetCost()
    {
        return _pizza.GetCost() + 2.00; // Adding cheese costs $2.00
    }
}

// Concrete Decorator 2: Adds pepper to the pizza
public class PepperDecorator : PizzaDecorator
{
    public PepperDecorator(Pizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return _pizza.GetDescription() + ", Pepper";
    }

    public override double GetCost()
    {
        return _pizza.GetCost() + 1.50; // Adding pepper costs $1.50
    }
}

// Concrete Decorator 3: Adds mushrooms to the pizza
public class MushroomDecorator : PizzaDecorator
{
    public MushroomDecorator(Pizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return _pizza.GetDescription() + ", Mushrooms";
    }

    public override double GetCost()
    {
        return _pizza.GetCost() + 1.75; // Adding mushrooms costs $1.75
    }
}

// Client: Builds and customizes the pizza
public class Program
{
    public static void Main()
    {
        // Start with a plain pizza
        Pizza plainPizza = new PlainPizza();
        Console.WriteLine($"{plainPizza.GetDescription()} - ${plainPizza.GetCost()}");

        // Add cheese
        Pizza cheesePizza = new CheeseDecorator(plainPizza);
        Console.WriteLine($"{cheesePizza.GetDescription()} - ${cheesePizza.GetCost()}");

        // Add pepper to the cheese pizza
        Pizza pepperCheesePizza = new PepperDecorator(cheesePizza);
        Console.WriteLine($"{pepperCheesePizza.GetDescription()} - ${pepperCheesePizza.GetCost()}");

        // Add mushrooms to the pepper cheese pizza
        Pizza deluxePizza = new MushroomDecorator(pepperCheesePizza);
        Console.WriteLine($"{deluxePizza.GetDescription()} - ${deluxePizza.GetCost()}");
    }
}


	public abstract class BasePizza
	{
		public abstract int GetCost();
	}

    //public class FarmHouse: BasePizza
    //{
    //    public override int GetCost() => 100;
    //}


    public class VegDelight: BasePizza
    {
        public override int GetCost() => 120;
    }


    //public class Margherita : BasePizza
    //{
    //    public override int GetCost() => 140;
    //}


    public abstract class ToppingDecorator : BasePizza
    {

    }

    public class ExtraCheese : ToppingDecorator
    {
        BasePizza basePizza;
        public ExtraCheese(BasePizza basePizza)
        {
            this.basePizza = basePizza;
        }
        public override int GetCost()
        {
            return this.basePizza.GetCost() + 10;
        }
    }

    public class ExtraMushroom : ToppingDecorator
    {
        BasePizza basePizza;
        public ExtraMushroom(BasePizza basePizza)
        {
            this.basePizza = basePizza;
        }
        public override int GetCost()
        {
            return this.basePizza.GetCost() + 20;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var pizza = new ExtraMushroom(new ExtraCheese(new VegDelight()));
        }
    }



}

