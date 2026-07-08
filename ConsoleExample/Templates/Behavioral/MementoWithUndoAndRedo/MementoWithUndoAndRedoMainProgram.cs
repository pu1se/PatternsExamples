using System.Collections.Generic;
using static System.Console;
namespace ConsoleExample.Templates.Behavioral.MementoWithUndoAndRedo;

public class MementoWithUndoAndRedoMainProgram
{
    public class Memento
    {
        public int Balance { get; }

        public Memento(int balance)
        {
            Balance = balance;
        }
    }



    public class BankAccount
    {
        private int balance;
        int overdraftLimit = -500;
        private Stack<Memento> mementoStates = new();
        private Stack<Memento> undone = new();

        public BankAccount()
        {
            mementoStates.Push(new Memento(balance));
        }

        public void Deposit(int amount)
        {
            balance += amount;
            WriteLine($"Deposited {amount}, balance now is {balance}");
            mementoStates.Push(new Memento(balance));
        }

        public void Withdraw(int amount)
        {
            if (balance - amount < overdraftLimit)
            {
                WriteLine($"You don't have enough money, balance is now {balance}");
                return;
            }

            balance -= amount;
            WriteLine($"Withdrew {amount}$, balance is now {balance}");
            mementoStates.Push(new Memento(balance));
        }

        public void Undo()
        {
            if (mementoStates.Count == 0)
                return;

            Memento memento;
            if (mementoStates.Count == 1)
            {
                memento = mementoStates.Pop();
                balance = memento.Balance;
                mementoStates.Push(memento);
                return;
            }

            var currentState = mementoStates.Pop();
            memento = mementoStates.Pop();
            balance = memento.Balance;
            mementoStates.Push(memento);

            undone.Push(currentState);
        }

        public void Redo()
        {
            if (undone.Count == 0)
                return;

            var memento = undone.Pop();
            balance = memento.Balance;
        }

        public override string ToString()
        {
            return $"Balance {balance}";
        }
    }

    public static void RunCode()
    {
        var bankAccount = new BankAccount();
        bankAccount.Deposit(100);
        bankAccount.Deposit(50);
        bankAccount.Deposit(25);

        bankAccount.Undo();
        WriteLine(bankAccount);

        bankAccount.Undo();
        WriteLine(bankAccount);

        bankAccount.Undo();
        WriteLine(bankAccount);

        bankAccount.Undo();
        WriteLine(bankAccount);

        bankAccount.Redo();
        WriteLine(bankAccount);

        bankAccount.Redo();
        WriteLine(bankAccount);

        bankAccount.Redo();
        WriteLine(bankAccount);

        bankAccount.Redo();
        WriteLine(bankAccount);
    }

}
