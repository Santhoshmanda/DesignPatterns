using System;
namespace Design_Patterns.Behavioral.Command
{
    /*
     1.Invoker
     2.Command
     3. Receiver
     
     */

    //This is receiver unchanged
    public class ACCWithUndo
    {
        public ACCWithUndo()
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

    public interface ICommandACC
    {
        public void Execute();
        public void Undo();
    }

    public class TurnOnAcCommandACC : ICommandACC
    {
        ACCWithUndo acc;
        public TurnOnAcCommandACC(ACCWithUndo acc)
        {
            this.acc = acc;
        }
        public void Execute()
        {
            acc.TurnONAC();
        }

        public void Undo()
        {
            acc.TurnOFFAC();
        }
    }

    public class TurnOFFAcCommandCC : ICommandACC
    {
        ACCWithUndo acc;
        public TurnOFFAcCommandCC(ACCWithUndo acc)
        {
            this.acc = acc;
        }
        public void Execute()
        {
            acc.TurnOFFAC();
        }
        public void Undo()
        {
            acc.TurnONAC();
        }
    }


    public class SetTempCommandCC : ICommandACC
    {
        ACCWithUndo acc;
        int temp;
        public SetTempCommandCC(ACCWithUndo acc, int temp)
        {
            this.acc = acc;
            this.temp = temp;
        }

            public void Execute()
            {
                acc.setTemp(this.temp);
            }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }

        //Invoker

        public class MyRemoteControlCC
        {
        ICommandACC command;
        Stack<ICommandACC> commandHistory = new Stack<ICommandACC>();
            public MyRemoteControlCC(ICommandACC command)
            {
                this.command = command;
            }

            public void PressButton()
            {
                command.Execute();
                commandHistory.Push(this.command);
            }

            public void Undo()
            {
            if (commandHistory.Count != 0)
            {
                var command = commandHistory.Pop();
                command.Undo();
            }

            }
        }


        public class ClientCC
        {
            public void Test()
            {
                var remoteControl = new MyRemoteControlCC(new TurnOnAcCommandACC(new ACCWithUndo()));//setup testing...
                remoteControl.PressButton();//client just simply press the btn
                remoteControl.Undo();

            }
        }
    
}

