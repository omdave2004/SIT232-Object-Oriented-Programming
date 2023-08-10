using System;

namespace BankSystem
{
    public class Account
    {
        private readonly string _name;
        private decimal _balance;

        // Getter for the account name
        public string Name { get { return _name; } }

        // Getter and setter for the account balance
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; } // add setter to allow updating the balance 
        }

        // Constructor that takes in the account holder name and the initial balance
        public Account(string name, decimal balance)
        {
            _name = name;
            _balance = balance;
        }

        // Method to deposit funds into the account
        public bool Deposit(decimal amount)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Amount must be greater than zero");
                }

                _balance += amount;

                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        // Method to withdraw funds from the account
        public bool Withdraw(decimal amount)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Amount must be greater than zero");
                }

                if (_balance < amount)
                {
                    throw new InvalidOperationException("Insufficient funds for withdrawal");
                }

                _balance -= amount;

                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        // Method to transfer funds from this account to another account
        public bool Transfer(Account toAccount, decimal amount)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Amount must be greater than zero");
                }

                if (_balance < amount)
                {
                    throw new InvalidOperationException("Insufficient funds for transfer");
                }

                _balance -= amount;
                toAccount.Deposit(amount);

                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                toAccount.Deposit(amount);
                return false;
            }
        }

        // Method to return a string representation of the account details
        public override string ToString()
        {
            return $"Name: {_name}, Balance: {_balance:C}";
        }       
    }
}
