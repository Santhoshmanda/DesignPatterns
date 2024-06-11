using System;
namespace Design_Patterns.Structural.Adapter
{

    //weight
    //xml to json conversion
    // Legacy system providing weather information in Fahrenheit
    class FahrenheitProvider
    {
        public double GetTemperatureFahrenheit()
        {
            // Simulate getting temperature in Fahrenheit from legacy system
            return 77.0; // Sample temperature in Fahrenheit
        }
    }

    // Interface expected by the new application (in Celsius)
    interface ICelsiusProvider
    {
        double GetTemperatureCelsius();
    }

    // Adapter to convert Fahrenheit temperature to Celsius
    class FahrenheitToCelsiusAdapter : ICelsiusProvider
    {
        private readonly FahrenheitProvider _fahrenheitProvider;

        public FahrenheitToCelsiusAdapter(FahrenheitProvider fahrenheitProvider)
        {
            _fahrenheitProvider = fahrenheitProvider;
        }

        public double GetTemperatureCelsius()
        {
            // Convert Fahrenheit to Celsius
            return (_fahrenheitProvider.GetTemperatureFahrenheit() - 32) * 5 / 9;
        }
    }

    // New application expecting temperature data in Celsius
    class NewApplication
    {
        private readonly ICelsiusProvider _celsiusProvider;

        public NewApplication(ICelsiusProvider celsiusProvider)
        {
            _celsiusProvider = celsiusProvider;
        }

        public void DisplayTemperature()
        {
            double temperatureCelsius = _celsiusProvider.GetTemperatureCelsius();
            Console.WriteLine($"Temperature in Celsius: {temperatureCelsius}°C");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FahrenheitProvider fahrenheitProvider = new FahrenheitProvider();
            FahrenheitToCelsiusAdapter adapter = new FahrenheitToCelsiusAdapter(fahrenheitProvider);

            NewApplication newApp = new NewApplication(adapter);
            newApp.DisplayTemperature();
        }
    }

}

