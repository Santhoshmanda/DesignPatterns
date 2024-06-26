﻿using System;
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

    
}

