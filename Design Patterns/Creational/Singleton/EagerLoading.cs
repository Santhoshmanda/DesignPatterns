using System;
namespace Design_Patterns.Creational.Singleton
{
	public class EagerLoading
	{
		public EagerLoading()
		{
		}
	}
    public class Student
    {
        private static readonly Student instance = new Student();

        // Private constructor to prevent instantiation
        private Student() { }

        public static Student getInstance() => instance;
    }

}

