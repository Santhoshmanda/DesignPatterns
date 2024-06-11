using System;
namespace Design_Patterns.Creational.Singleton
{
	public class ThreadSafeLazyLoading
	{
		public ThreadSafeLazyLoading()
		{
		}
	}
    //all the threads have to acquire lock, lock is expensie
    public class LazyStudentThreadSafe
    {
        private static LazyStudentThreadSafe lazyInstance;
        public static object lockobject = new Object();

        // Private constructor to prevent instantiation
        private LazyStudentThreadSafe() { }

        public static LazyStudentThreadSafe getInstance()
        {
            lock (lockobject)
            {


                if (lazyInstance == null)
                {
                    return new LazyStudentThreadSafe();
                }
                return lazyInstance;
            }
        }
    }

    //other threads checks if not null directly return the obj
    //simulatneously threads one enters acquire lock then checks then creats
    //the seocnd thread then acquire lock check if the obj has already created if yes 

    public class LazyStudentThreadSafeDoublelockchecking
    {
        private static LazyStudentThreadSafeDoublelockchecking lazyInstance;
        public static object lockobject = new Object();

        // Private constructor to prevent instantiation
        private LazyStudentThreadSafeDoublelockchecking() { }

        public static LazyStudentThreadSafeDoublelockchecking getInstance()
        {

            if (lazyInstance == null)
            {
                lock (lockobject)
                {
                    if (lazyInstance == null)
                    {
                        return new LazyStudentThreadSafeDoublelockchecking();
                    }
                 

                }

            }
            return lazyInstance;

        }
    }
}

