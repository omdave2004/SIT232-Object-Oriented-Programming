using System;
using BankingSystem;

public class WithdrawTransaction : Transaction
{
    private Account _account;

    public WithdrawTransaction(decimal amount, Account account) : base(amount)
    {
        _account = account;
    }

    public override void Execute()
    {
        if (!_executed && !_reversed)
        {
            _executed = true;
            _dateStamp = DateTime.Now;

            try
            {
                _account.Withdraw(_amount);
                _success = true;
            }
            catch (Exception)
            {
                _success = false;
            }
        }
    }

    public override void Rollback()
    {
        if (_executed && !_reversed)
        {
            _reversed = true;
            _dateStamp = DateTime.Now;

            try
            {
                _account.Deposit(_amount);
            }
            catch (Exception)
            {
                // If deposit fails, just ignore it
            }
        }
    }
}
