using System;
namespace Design_Patterns.Structural.Decorator.Pizza
{


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

