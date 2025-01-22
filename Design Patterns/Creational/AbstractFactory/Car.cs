using System;
namespace Design_Patterns.Creational.AbstarctFactory
{	using System;
namespace AbstractFactoryDesignPattern
{
    // Abstract Products
    public interface IButton
    {
        void Click();
    }

    public interface ITextBox
    {
        void Write(string text);
    }

    // Concrete Products for Windows
    public class WindowsButton : IButton
    {
        public void Click()
        {
            Console.WriteLine("Windows Button Clicked");
        }
    }

    public class WindowsTextBox : ITextBox
    {
        public void Write(string text)
        {
            Console.WriteLine($"Text Written in Windows TextBox: {text}");
        }
    }

    // Concrete Products for MacOS
    public class MacOSButton : IButton
    {
        public void Click()
        {
            Console.WriteLine("MacOS Button Clicked");
        }
    }

    public class MacOSTextBox : ITextBox
    {
        public void Write(string text)
        {
            Console.WriteLine($"Text Written in MacOS TextBox: {text}");
        }
    }

    // Abstract Factory
    public interface IUIFactory
    {
        IButton CreateButton();
        ITextBox CreateTextBox();
    }

    // Concrete Factory for Windows
    public class WindowsUIFactory : IUIFactory
    {
        public IButton CreateButton() => new WindowsButton();

        public ITextBox CreateTextBox() => new WindowsTextBox();
    }

    // Concrete Factory for MacOS
    public class MacOSUIFactory : IUIFactory
    {
        public IButton CreateButton() => new MacOSButton();

        public ITextBox CreateTextBox() => new MacOSTextBox();
    }

    // Client
    public class Application
    {
        private readonly IButton _button;
        private readonly ITextBox _textBox;

        public Application(IUIFactory factory)
        {
            _button = factory.CreateButton();
            _textBox = factory.CreateTextBox();
        }

        public void Render()
        {
            _button.Click();
            _textBox.Write("Sample Text");
        }
    }
    
    // Testing the Abstract Factory Design Pattern
    // Client Code
    public class Client
    {
        public static void Main()
        {
            IUIFactory factory;

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                factory = new WindowsUIFactory();
            }
            else
            {
                factory = new MacOSUIFactory();
            }

            var app = new Application(factory);
            app.Render();

            Console.ReadKey();
        }
    }
}
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

