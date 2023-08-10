using System;

namespace BankSystem
{
    class WithdrawTransaction
    {
        private readonly Account account; // The account from which the withdrawal is made
        private readonly decimal amount; // The amount to be withdrawn
        private bool executed; // Flag to indicate if the transaction has been executed
        private bool success; // Flag to indicate if the transaction was successful
        private bool reversed; // Flag to indicate if the transaction has been reversed

        public bool Executed { get { return executed; } } // Getter for executed flag
        public bool Success { get { return success; } } // Getter for success flag
        public bool Reversed { get { return reversed; } } // Getter for reversed flag

        public WithdrawTransaction(Account account, decimal amount) // Constructor to initialize the account and amount fields
        {
            this.account = account;
            this.amount = amount;
        }

        public void Print() // Method to print details of the withdrawal transaction
        {
            Console.WriteLine($"Withdraw ${amount} from {account.Name}'s account");
            Console.WriteLine($"Executed: {executed}, Success: {success}, Reversed: {reversed}");
        }

        public void Execute()
        {
            try
            {
                if (executed)
                    throw new InvalidOperationException("Transaction has already been executed");

                if (amount > account.Balance)
                    throw new InvalidOperationException("Invalid balance");

                success = account.Withdraw(amount);
                executed = true;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void Rollback()
        {
            try
            {
                if (!executed)
                    throw new InvalidOperationException("Transaction has not been executed yet");

                if (!success)
                    throw new InvalidOperationException("Transaction was unsuccessful, cannot rollback");

                if (reversed)
                    throw new InvalidOperationException("Transaction has already been reversed");

                account.Deposit(amount);
                reversed = true;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
