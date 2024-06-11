using System;
namespace Design_Patterns.Behavioral.NullObject.cs
{
    //A null Object replaces nul return type
    //No need to put if check for checking null
    //null object reflects do nothing or default behaviour

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

    public class NullObjectLogger : ILogger
    {
        public void Log()
        {

         //generallly properties are access so it will have 0 or something

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
                    //return null;
                    return new NullObjectLogger();
                }

            }
        }

        public enum LoggerType
        {
            DB, Console, File
        }

    public class TestClass
    {
        public void Test()
        {
            //var factory=LoggerFactory.CreateLogger() suppose it accepts string and we are gving some random
            //it will then return null
            //factory.log(); //throws null pointer execption so to avaoid it return a  nulobjet;
            //if(factory!==null) then factory.log();//to avoid if conditon null object dp can be used.
        }
    }

    }

