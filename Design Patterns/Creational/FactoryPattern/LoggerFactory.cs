using System;
namespace Design_Patterns.Creational.FactoryPattern
{
	public interface ILogger
	{
		void Log();
	}

    public class DBLogger : ILogger
    {
        public void Log()
        {
            Console.Write("Db logger");
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log()
        {

            Console.Write("ConsoleLogger");

        }
    }

    public class FileLogger : ILogger
    {
        public void Log()
        {

            Console.Write("FileLogger");

        }
    }



    public static class LoggerFactory
	{


        public static ILogger CreateLogger(LoggerType loggerType)
        {
            switch (loggerType)
            {
                case LoggerType.DB:
                    return new DBLogger();
                case LoggerType.Console:
                    return new ConsoleLogger();
                case LoggerType.File:
                    return new FileLogger();

                default:
                    return null;
            }

        }
	}

    public enum LoggerType
    {
        DB,Console,File
    }
    using System;

namespace FactoryMethodPatternExample
{
    // Step 1: Logger Interface
    public interface ILogger
    {
        void Log(string message);
    }

    // Step 2: Concrete Loggers
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[ConsoleLogger] {message}");
        }
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            // Simulate writing to a file
            Console.WriteLine($"[FileLogger] Writing to file: {message}");
        }
    }

    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            // Simulate writing to a database
            Console.WriteLine($"[DatabaseLogger] Writing to database: {message}");
        }
    }

    // Step 3: Factory Base Class
    public abstract class LoggerFactory
    {
        public abstract ILogger CreateLogger(); // Factory Method

        // Common logic shared by all loggers
        public void LogMessage(string message)
        {
            ILogger logger = CreateLogger(); // Call the factory method
            logger.Log(message);
        }
    }

    // Step 4: Concrete Factories
    public class ConsoleLoggerFactory : LoggerFactory
    {
        public override ILogger CreateLogger()
        {
            return new ConsoleLogger();
        }
    }

    public class FileLoggerFactory : LoggerFactory
    {
        public override ILogger CreateLogger()
        {
            return new FileLogger();
        }
    }

    public class DatabaseLoggerFactory : LoggerFactory
    {
        public override ILogger CreateLogger()
        {
            return new DatabaseLogger();
        }
    }

    // Step 5: Client Code
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Console Logger
            LoggerFactory consoleLoggerFactory = new ConsoleLoggerFactory();
            consoleLoggerFactory.LogMessage("This is a message for the Console Logger.");

            // Create a File Logger
            LoggerFactory fileLoggerFactory = new FileLoggerFactory();
            fileLoggerFactory.LogMessage("This is a message for the File Logger.");

            // Create a Database Logger
            LoggerFactory databaseLoggerFactory = new DatabaseLoggerFactory();
            databaseLoggerFactory.LogMessage("This is a message for the Database Logger.");
        }
    }
}

}

