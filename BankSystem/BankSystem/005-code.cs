using System;

namespace BankSystem
{
    class TransferTransaction
    {
        private Account _fromAccount; // account from which the transfer is made
        private Account _toAccount; // account to which the transfer is made
        private decimal _amount; // amount to be transferred
        private DepositTransaction _deposit; // instance of DepositTransaction class
        private WithdrawTransaction _withdraw; // instance of WithdrawTransaction class
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

        // Constructor to initialize the fields of the TransferTransaction class.
        // It takes in the two accounts involved in the transfer and the amount to be transferred.
        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amount = amount;

            // create instances of DepositTransaction and WithdrawTransaction classes
            _withdraw = new WithdrawTransaction(_fromAccount, _amount);
            _deposit = new DepositTransaction(_toAccount, _amount);
        }

        // Method to print the details of the transfer transaction.
        public void Print()
        {
            Console.WriteLine("Transferred ${0} from {1}'s account to {2}'s account", _amount, _fromAccount.Name, _toAccount.Name);
            _withdraw.Print();
            _deposit.Print();
        }

        // Method to execute the transfer transaction.
        // It first withdraws the specified amount from the fromAccount using the WithdrawTransaction instance.
        // Then, it deposits the same amount into the toAccount using the DepositTransaction instance.
        public void Execute()
        {
            if (_executed)
            {
                throw new InvalidOperationException("Transaction has already been executed");
            }

            try
            {
                _withdraw.Execute();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            bool depositSuccess = _deposit.Execute();
            if (!depositSuccess)
            {
                _withdraw.Rollback();
                return;
            }

            _executed = true;
        }

        // Method to reverse the transfer transaction.
        // It first rolls back the deposit made into the toAccount using the DepositTransaction instance.
        // Then, it rolls back the withdrawal made from the fromAccount using the WithdrawTransaction instance.
        public void Rollback()
        {
            if (_reversed)
            {
                throw new InvalidOperationException("Transaction has already been reversed");
            }

            if (!_executed)
            {
                throw new InvalidOperationException("Transaction has not been executed yet");
            }

            _deposit.Rollback();
            _withdraw.Rollback();

            _reversed = true;
        }
    }
}
