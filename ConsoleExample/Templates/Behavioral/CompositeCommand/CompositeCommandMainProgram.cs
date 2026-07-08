using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleExample.Templates.Behavioral.ChainOfCommands
{
    public class BankAccount
    {
        private int balance;
        int overdraftLimit = -500;

        public bool Deposit(int amount)
        {
            balance += amount;
            WriteLine($"Deposited {amount}, balance now is {balance}");
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount;
                WriteLine($"Withdrew {amount}$, balance is now {balance}");
                return true;
            }
            else
            {
                WriteLine($"You don't have enough money, balance is now {balance}");
                return false;
            }
        }

        public override string ToString()
        {
            return $"Balance {balance}";
        }
    }

    public interface ICommand
    {
        void Call(); // I like more Execute or Handle
        void Undo();
        bool FinishedSuccessfully { get; }
    }

    public enum ActionType
    {
        Deposit, Withdraw
    }

    public class BankAccountCommand(BankAccount _bankAccount, ActionType _actionType, int _amount) : ICommand
    {
        public bool FinishedSuccessfully { get; private set; }

        public void Call()
        {
            switch (_actionType)
            {
                case ActionType.Deposit:
                    FinishedSuccessfully = _bankAccount.Deposit(_amount);
                    break;
                case ActionType.Withdraw:
                    FinishedSuccessfully = _bankAccount.Withdraw(_amount);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        public void Undo()
        {
            if (FinishedSuccessfully == false)
            {
                return;
            }

            switch (_actionType)
            {
                case ActionType.Deposit:
                    _bankAccount.Withdraw(_amount);
                    break;
                case ActionType.Withdraw:
                    _bankAccount.Deposit(_amount);
                    break;

                default: throw new NotImplementedException();
            }
        }
    }

    public class CompositeBankAccountCommand : List<BankAccountCommand>, ICommand
    {
        public virtual void Call()
        {
            this.ForEach(x => x.Call());
        }

        public virtual void Undo()
        {
            Enumerable.Reverse(this).ToList().ForEach(x => x.Undo());
        }

        public bool FinishedSuccessfully => this.All(x => x.FinishedSuccessfully);
    }

    public class MoneyTransferCommand : CompositeBankAccountCommand
    {
        public MoneyTransferCommand(BankAccount from, BankAccount to, int amount)
        {
            Add(new BankAccountCommand(from, ActionType.Withdraw, amount));
            Add(new BankAccountCommand(to, ActionType.Deposit, amount));
        }

        public override void Call()
        {
            BankAccountCommand lastCommand = null;
            foreach (var command in this)
            {
                if (lastCommand == null || lastCommand.FinishedSuccessfully)
                {
                    command.Call();
                    lastCommand = command;
                }
                else
                {
                    continue;
                }
            }
        }
    }

    internal static class CompositeCommandMainProgram // I prefer name ChainOfCommands
    {
        public static void RunCode()
        {
            var from = new BankAccount();
            from.Deposit(100);
            var to = new BankAccount();

            var transferMoney = new MoneyTransferCommand(from, to, 1000);
            transferMoney.Call();
            WriteLine(from);
            WriteLine(to);

            transferMoney.Undo();
            WriteLine(from);
            WriteLine(to);
        }
    }
}
