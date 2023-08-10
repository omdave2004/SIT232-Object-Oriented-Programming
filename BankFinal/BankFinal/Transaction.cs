using System;

public abstract class Transaction
{
    protected decimal _amount;
    protected bool _success;
    private bool _executed;
    private bool _reversed;
    private DateTime _dateStamp;

    public Transaction(decimal amount)
    {
        _amount = amount;
    }

    public bool Success
    {
        get { return _success; }
    }

    public bool Executed
    {
        get { return _executed; }
    }

    public bool Reversed
    {
        get { return _reversed; }
    }

    public DateTime DateStamp
    {
        get { return _dateStamp; }
    }

    public abstract void Execute();

    public virtual void Rollback()
    {
        if (_executed && !_reversed)
        {
            _reversed = true;
            _dateStamp = DateTime.Now;
        }
    }

    public virtual void Print()
    {
        Console.WriteLine($"Transaction of {Math.Round(_amount, 2)} at {DateStamp}, status: {(Success ? "success" : "failure")}");
    }
}
