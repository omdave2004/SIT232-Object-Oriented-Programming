using System;

namespace BankingSystem
{
    class TransferTransaction : Transaction
    {
        private Account _sourceAccount;
        private Account _targetAccount;

        public TransferTransaction(decimal amount, Account sourceAccount, Account targetAccount) : base(amount)
        {
            _sourceAccount = sourceAccount;
            _targetAccount = targetAccount;
        }

        public override void Execute()
        {
            base.Execute();
            _sourceAccount.Withdraw(_amount);
            _targetAccount.Deposit(_amount);
        }

        public override void Rollback()
        {
            base.Rollback();
            _sourceAccount.Deposit(_amount);
            _targetAccount.Withdraw(_amount);
        }

        public override void Print()
        {
            Console.WriteLine($"Transaction Type: Transfer\nAmount: {_amount:C}\nStatus: {Success}\nDate: {DateStamp}\nSource Account: {_sourceAccount.Id}\nTarget Account: {_targetAccount.Id}\n");
        }
    }
}
