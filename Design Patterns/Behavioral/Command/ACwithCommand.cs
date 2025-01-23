using System;
namespace Design_Patterns.Behavioral.Command
{

    /*
     1.Invoker
     2.Command
     3. Receiver
     
     */

    //This is receiver unchanged
	public class ACC
	{
		public ACC()
		{
		}
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

    //command

    public interface ICommand
    {
        public void Execute();
    }

    public class TurnOnAcCommand : ICommand
    {
        ACC acc;
        public TurnOnAcCommand(ACC acc)
        {
            this.acc = acc;
        }
        public void Execute()
        {
            acc.TurnONAC();
        }
    }

    public class TurnOFFAcCommand : ICommand
    {
        ACC acc;
        public TurnOFFAcCommand(ACC acc)
        {
            this.acc = acc;
        }
        public void Execute()
        {
            acc.TurnOFFAC();
        }
    }


    public class SetTempCommand : ICommand
    {
        ACC acc;
        int temp;
        public SetTempCommand(ACC acc, int temp)
        {
            this.acc = acc;
            this.temp = temp;
        }
        public void Execute()
        {
            acc.setTemp(this.temp);
        }
    }

    //Invoker

    public class MyRemoteControl
    {
        ICommand command;
        public MyRemoteControl(ICommand command)
        {
            this.command = command;
        }

        public void PressButton()
        {
            command.Execute();
        }
    }


    public class Client
    {
        public void Test()
        {
            var remoteControl = new MyRemoteControl(new TurnOnAcCommand(new ACC()));//setup testing...
            remoteControl.PressButton();//client just simply press the btn

        }
    }

	The Process of Encapsulation:
The request (such as "turn on the AC", "turn off the AC", or "set the temperature") is encapsulated inside command objects like TurnOnAcCommand, TurnOFFAcCommand, or SetTempCommand.
These objects encapsulate the action, holding all the information needed to perform it.
The Invoker (MyRemoteControl) triggers the action by invoking the Execute() method, which internally calls the appropriate method on the receiver (ACC).
	 The Invoker doesn't need to know the details of the action or how the request is handled. It just knows how to invoke the command by calling Execute().

    Why is This Encapsulation Beneficial?
Decoupling: The client doesn't need to directly interact with the receiver (ACC). Instead, it interacts with the command objects. This decouples the client from the details of how the actions are performed.

Extensibility: New actions can be added easily by creating new concrete command classes without modifying the invoker or receiver.

Command History: You could easily implement features like undo/redo by storing the command objects and their states.
}

