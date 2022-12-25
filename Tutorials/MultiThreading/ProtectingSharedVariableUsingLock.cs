using System;
using System.Threading;

class ProtectingSharedVariableUsingLock
{
    public static void Main()
    {
        var counter = new Counter();
        var t1 = new Thread(counter.IncrementCounter);
        var t2 = new Thread(counter.IncrementCounter);
        var t3 = new Thread(counter.IncrementCounter);

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine($"Counter = {counter.GetValue()}");
    }
}


public class Counter
{
    private readonly object _counterLock = new Object();
    private int _counter = 0;

    public void IncrementCounter()
    {
        for (int i = 0; i < 100; i++)
        {
            lock (_counterLock)
            {
                _counter++;
            }
        }
    }

    public int GetValue()
    {
        lock (_counterLock)
        {
            return _counter;
        }
    }
}