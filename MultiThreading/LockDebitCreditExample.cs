using System;
using System.Threading;

public class LockDebitCreditExample
{
    public static void Main()
    {

        Account account = new Account(8000);

        var t1 = new Thread(() =>
        {
            for (int i = 0; i < 1000; i++)
            {
                account.Debit(2);
            }
        });

        var t2 = new Thread(() =>
        {
            for (int i = 0; i < 1000; i++)
            {
                account.Credit(3);
            }
        });

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine($"Account Balance is {account.GetBalance()}");

    }
}
public class Account
{
    private readonly object balanceLock = new object();
    private decimal _balance;

    public Account(decimal initialBalance) => this._balance = initialBalance;

    public decimal Debit(decimal debitAmount)
    {

        if (debitAmount < 0) throw new ArgumentOutOfRangeException(nameof(debitAmount), "The debit amount cannot be negative.");

        decimal appliedAmount = 0;

        lock (balanceLock)
        {
            if (_balance >= debitAmount)
            {
                _balance -= debitAmount;
                appliedAmount = debitAmount;
            }
        }

        return appliedAmount;
    }

    public void Credit(decimal creditAmount)
    {

        if (creditAmount < 0) throw new ArgumentOutOfRangeException(nameof(creditAmount), "The credit amount cannot be negative.");

        lock (balanceLock)
        {
            _balance += creditAmount;
        }
    }

    public decimal GetBalance()
    {
        lock (balanceLock)
        {
            return _balance;
        }
    }
}
