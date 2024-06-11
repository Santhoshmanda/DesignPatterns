using System;
namespace Design_Patterns.Behavioral.State
{
    

    // State interface
    interface VendingMachineState
    {
        void SelectItem(VendingMachine vendingMachine);
        void InsertMoney(VendingMachine vendingMachine);
        void DispenseItem(VendingMachine vendingMachine);
    }

    // Concrete state classes
    class IdleState : VendingMachineState
    {
        public void SelectItem(VendingMachine vendingMachine)
        {
            Console.WriteLine("Item selected.");
            vendingMachine.SetState(new ItemSelectedState());
        }

        public void InsertMoney(VendingMachine vendingMachine)
        {
            Console.WriteLine("Please select an item first.");
        }

        public void DispenseItem(VendingMachine vendingMachine)
        {
            Console.WriteLine("Please select and pay for an item first.");
        }
    }

    class ItemSelectedState : VendingMachineState
    {
        public void SelectItem(VendingMachine vendingMachine)
        {
            Console.WriteLine("Item changed.");
        }

        public void InsertMoney(VendingMachine vendingMachine)
        {
            Console.WriteLine("Money inserted.");
            vendingMachine.SetState(new PaymentProcessingState());
        }

        public void DispenseItem(VendingMachine vendingMachine)
        {
            Console.WriteLine("Please pay for the selected item first.");
        }
    }

    class PaymentProcessingState : VendingMachineState
    {
        public void SelectItem(VendingMachine vendingMachine)
        {
            Console.WriteLine("Please complete the current transaction first.");
        }

        public void InsertMoney(VendingMachine vendingMachine)
        {
            Console.WriteLine("Payment already processing.");
        }

        public void DispenseItem(VendingMachine vendingMachine)
        {
            Console.WriteLine("Item dispensed.");
            vendingMachine.SetState(new IdleState());
        }
    }

    // Context class
    class VendingMachine
    {
        private VendingMachineState currentState;

        public VendingMachine()
        {
            // Initialize with default state
            currentState = new IdleState();
        }

        public void SetState(VendingMachineState state)
        {
            currentState = state;
        }

        public void SelectItem()
        {
            currentState.SelectItem(this);
        }

        public void InsertMoney()
        {
            currentState.InsertMoney(this);
        }

        public void DispenseItem()
        {
            currentState.DispenseItem(this);
        }
    }
    class ProgramTestState
    {
        static void MainState(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();

            vendingMachine.SelectItem();
            vendingMachine.InsertMoney();
            vendingMachine.DispenseItem();

            Console.ReadLine();
        }
    }




}

