using System;
namespace Design_Patterns.Creational.AbstarctFactory
{
	public interface Car
	{
		int GetTopSpeed();
	}

    public class EconomicCar1 : Car
    {
        public int GetTopSpeed() => 100;
    }
    public class EconomicCar2 : Car
    {
        public int GetTopSpeed() => 150;
    }
    public class LuxaryCar1 : Car
    {
        public int GetTopSpeed() => 300;
    }
    public class LuxaryCar2 : Car
    {
        public int GetTopSpeed() => 350;
    }


    public interface AbstractFactory
    {
        Car GetCar(Cartype cartype);
    }
    public class EconomicCarFactory: AbstractFactory
    {
        public Car GetCar(Cartype cartype)
        {
            switch (cartype)
            {
                case Cartype.Economic1:
                    return new EconomicCar1();
                case Cartype.Economic2:
                    return new EconomicCar2();
                default:
                    return null;
            }


        }

    }

    public class LuxaryCarFactory : AbstractFactory
    {
        public Car GetCar(Cartype cartype)
        {
            switch (cartype)
            {
                case Cartype.Luxary1:
                    return new LuxaryCar1();
                case Cartype.Luxary2:
                    return new LuxaryCar2();
                default:
                    return null;
            }


        }

    }


    public class AbstractFactoryProducer
    {
        public AbstractFactory GetfactoryInstance(string value)
        {
            if (value == "Economic")
            {
                return new EconomicCarFactory();
            }
            else if (value =="Luxary")
            {
                return new LuxaryCarFactory();
            }
            return null;

        }

    }

    public enum Cartype
    {
        Economic1,Economic2,Luxary1,Luxary2
    }
}

