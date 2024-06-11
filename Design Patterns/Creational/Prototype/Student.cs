using System;
namespace Design_Patterns.Creational.Prototype
{
    //SHALLOW VS DEEP COPY
    //If the field is a value type, a bit-by-bit copy of the field is performed. If the field is a reference type, the reference is copied, not the actual object. 
    //suppose I want to clone a student

    public class Student
	{
		public int age;
		private int rollNumber;
		public string name;
		public Student()
		{

		}
		public Student(int age, int rollNumber, string name)
		{
			this.age = age;
			this.rollNumber = rollNumber;
			this.name = name;
		}


	}

	public class TestClass
	{
		public void clone()
		{
			Student orginalStudent = new Student(10,1234,"sam");
			Student clonedStundent = new Student();
			clonedStundent.name = orginalStudent.name;
            //.. so client has to know all the info about the params
            //wont be able to access the private members
            //what if the object is complex so hand over the clone repsosniblity  to the class itself
            StudentWithClone orginalStudentclone = new StudentWithClone(10, 1234, "sam");
            StudentWithClone dup = orginalStudentclone.Clone();

        }
     
    }

    public class StudentWithClone
    {
        public int age;
        private int rollNumber;
        public string name;
        public StudentWithClone()
        {

        }
        public StudentWithClone(int age, int rollNumber, string name)
        {
            this.age = age;
            this.rollNumber = rollNumber;
            this.name = name;
        }

		public StudentWithClone Clone()
		{
			return (StudentWithClone)this.MemberwiseClone();
			//return new StudentWithClone(age,rollNumber,name);
		}


    }
}

