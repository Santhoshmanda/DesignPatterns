using System;
namespace Design_Patterns.Behavioral.Command
{
	public class AC
	{
		public bool IsOn { get; set; }
		public int Temp { get; set; }

		public void TurnONAC()
		{
			this.IsOn = true;
		}
        public void TurnOFFAC()
        {
            this.IsOn = false;
        }
        public void setTemp(int value)
        {
            this.Temp = value;
        }

    }
    /* 
     * Cons: 1. Lack Of Abstraction
     * Today, Process of turing on AC is simple, bt if there are more steps, client has to aware of all of that, which is not good
     * 2. Undo/Redo Functionality:
     * what if I want to implement undo redo func. How it will be handled?
     * 3. Difficulty in code maintanenece
     * what if in future if we want to support more commands for more devices example Bulb
     
     
     */
    public class ClientTest
    {
        public void Test()
        {
            AC ac = new AC();
            ac.TurnONAC();
            ac.setTemp(25);
            ac.TurnOFFAC();
            
        }
    }
}

