using System;

namespace BankSystem
{
    class DepositTransaction
    {
        private Account _account; // account into which the deposit is made
        private decimal _amount; // amount to be deposited
        private bool _executed; // indicates whether the transaction has been executed
        private bool _reversed; // indicates whether the transaction has been reversed

        public bool Executed
        {
            get { return _executed; }
        }

        public bool Reversed
        {
            get { return _reversed; }
        }

        // Constructor to initialize the fields of the DepositTransaction class.
        // It takes in the account into which the deposit is made and the amount to be deposited.
        public DepositTransaction(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        // Method to print the details of the deposit transaction.
        public void Print()
        {
            Console.WriteLine("Deposited ${0} into {1}'s account", _amount, _account.Name);
        }

        // Method to execute the deposit transaction.
        // It adds the specified amount to the balance of the account.
        // Returns true if the transaction was successful, false otherwise.
        public bool Execute()
        {
            try
            {
                if (_executed)
                {
                    throw new InvalidOperationException("Transaction has already been executed");
                }

                decimal newBalance = _account.Balance + _amount;
                if (newBalance < 0)
                {
                    Console.WriteLine("Invalid balance after deposit. Transaction canceled.");
                    return false;
                }

                _account.Balance = newBalance;
                _executed = true;
                return true;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Method to reverse the deposit transaction.
        // It subtracts the deposited amount from the balance of the account.
        public void Rollback()
        {
            try
            {
                if (_reversed)
                {
                    throw new InvalidOperationException("Transaction has already been reversed");
                }

                if (!_executed)
                {
                    throw new InvalidOperationException("Transaction has not been executed yet");
                }

                _account.Balance -= _amount;
                _reversed = true;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
