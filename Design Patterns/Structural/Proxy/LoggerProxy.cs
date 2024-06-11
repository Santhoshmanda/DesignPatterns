using System;
namespace Design_Patterns.Structural.Proxy
{
    interface ICalculator
    {
        int Add(int a, int b);
    }

    class Calculator : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    class LoggingProxy : ICalculator
    {
        private readonly ICalculator _calculator;

        public LoggingProxy(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public int Add(int a, int b)
        {
            Console.WriteLine($"Add method called with arguments: {a}, {b}");
            int result = _calculator.Add(a, b);
            Console.WriteLine($"Result: {result}");
            return result;
        }
    }

    class ProgramTest123
    {
        static void Main(string[] args)
        {
            ICalculator calculator = new LoggingProxy(new Calculator());
            int sum = calculator.Add(5, 3);
            Console.WriteLine($"Sum: {sum}");
        }
    }

}

