using System;
namespace Design_Patterns.Behavioral.ChainOfResponsibility
{
	public class Logger
	{
		public Logger()
		{
		}
	}

	/* 
	 Abstarct Handler
	 Concrete Handlers
	 eg: ATM, Vending Machine, Logger
	 */


	public abstract class LogProcesser
	{
		public static int INFO = 1;
        public static int DEBUG = 2;
        public static int ERROR = 3;
		LogProcesser nextLogProcesser;
		public LogProcesser(LogProcesser nextLogProcesser)
		{
			this.nextLogProcesser = nextLogProcesser;

		}

		public virtual void Log(int logLevel, string message)
		{
			if (nextLogProcesser != null)
			{
				nextLogProcesser.Log(logLevel, message);
			}
		}

    }

	// concrete handlers

	public class InfoLogProcesser: LogProcesser
	{
		public InfoLogProcesser(LogProcesser nextLogProcesser):base(nextLogProcesser)
		{
				
		}

		public override void Log(int loglevel, string message)
		{
			if (loglevel == INFO)
			{
				Console.WriteLine("Info log");
			}
			else
			{
				base.Log(loglevel, message);
			}
		}
	}

    


    public class DebugLogProcesser : LogProcesser
    {
        public DebugLogProcesser(LogProcesser nextLogProcesser) : base(nextLogProcesser)
        {

        }

        public override void Log(int loglevel, string message)
        {
            if (loglevel == DEBUG)
            {
                Console.WriteLine("Info log");
            }
            else
            {
                base.Log(loglevel, message);
            }
        }
    }

    public class ErrorLogProcesser : LogProcesser
    {
        public ErrorLogProcesser(LogProcesser nextLogProcesser) : base(nextLogProcesser)
        {

        }

        public override void Log(int loglevel, string message)
        {
            if (loglevel == ERROR)
            {
                Console.WriteLine("Info log");
            }
            else
            {
                base.Log(loglevel, message);
            }
        }
    }


    public class Client
	{
		public void Test()
		{
			LogProcesser logProcesser = new InfoLogProcesser(new DebugLogProcesser(new ErrorLogProcesser(null)));
			logProcesser.Log(3,"errorMessage");
		}
	}


}

