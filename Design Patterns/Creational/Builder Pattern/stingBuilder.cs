using System.Text;

namespace Design_Patterns.Creational.BuilderPattern
{
    public  class stingBuilder
	{
		public string Build()
		{
            StringBuilder builder = new StringBuilder();
            builder.Append("Hello");
            builder.Append(" ");
            builder.Append("World");
            string result = builder.ToString();
            return result;
            //Console.WriteLine(result); // Output: Hello World

        }
        

	}
}

