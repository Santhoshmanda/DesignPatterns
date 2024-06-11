using System;
namespace Design_Patterns.Creational.Singleton
{
	public class Lazyloading
	{
		public Lazyloading()
		{
		}
	}
    //but not thread safe
    public class LazyStudent
    {
        private static LazyStudent lazyInstance;

        // Private constructor to prevent instantiation
        private LazyStudent() { }

        public static LazyStudent getInstance()
        {
            if (lazyInstance == null)
            {
                return new LazyStudent();
            }
            return lazyInstance;
        }
    }


}

