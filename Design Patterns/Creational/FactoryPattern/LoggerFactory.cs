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
}

