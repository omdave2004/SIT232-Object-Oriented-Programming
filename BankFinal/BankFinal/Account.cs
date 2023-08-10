using System;

namespace BankingSystem
{
    public abstract class Account
    {
        protected decimal _balance;
        private readonly int _accountNumber;

        public decimal Balance { get { return _balance; } }
        public int AccountNumber { get { return _accountNumber; } }

        protected Account(decimal initialBalance, int accountNumber)
        {
            _balance = initialBalance;
            _accountNumber = accountNumber;
        }

        public abstract void Withdraw(decimal amount);
        public abstract void Deposit(decimal amount);

        public virtual void PrintAccountDetails()
        {
            Console.WriteLine("Account number: " + _accountNumber);
            Console.WriteLine("Balance: " + _balance);
        }
    }
}
