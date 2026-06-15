using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleExample.Templates.Behavioral.Command
{
    public class BankAccount
    {
        private int balance;
        int overdraftLimit = -500;

        public void Deposit(int amount)
        {
            balance += amount;
            WriteLine($"Deposited {amount}, balance now is {balance}");
        }

        public void Withdraw(int amount)
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount;
                WriteLine($"Withdrew {amount}$, balance is now {balance}");
            }
            else
            {
                WriteLine($"You don't have enough money, balance is now {balance}");
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
    }

    public enum ActionType
    {
        Deposit, Withdraw
    }

    public class BankAccountCommand(BankAccount _bankAccount, ActionType _actionType, int _amount) : ICommand
    {
        public void Call()
        {
            switch (_actionType)
            {
                case ActionType.Deposit:
                    _bankAccount.Deposit(_amount);
                    break;
                case ActionType.Withdraw:
                    _bankAccount.Withdraw(_amount);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        public void Undo()
        {
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

    internal static class CommandMainProgram
    {
        public static void RunCode()
        {
            var bankAccount = new BankAccount();
            List<BankAccountCommand> commands = [
                new BankAccountCommand(bankAccount, ActionType.Deposit, 100),
                new BankAccountCommand(bankAccount, ActionType.Withdraw, 50)
            ];

            WriteLine(bankAccount);

            commands.ForEach(x => x.Call());

            WriteLine(bankAccount);

            commands.Reverse();
            commands.ForEach(x => x.Undo());

            WriteLine(bankAccount);
        }
    }
}
