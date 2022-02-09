using System;
using System.Threading;
using System.Collections.Generic;

class Lock_BasicExample
{
    public static void Main()
    {
        Demo d = new Demo();
        d.SharedResourceDemo();
    }
}

class Demo
{
    private int _shared;
    private int Shared
    {
        get => _shared;
        set
        {
            Thread.Sleep(10);
            _shared = value;
        }
    }

    ManualResetEvent evt = new ManualResetEvent(false);
    object sync = new object();

    public void SharedResourceDemo()
    {
        Shared = 0;
        int n = 100;
        var threads = new List<Thread>();

        for (int i = 0; i < n; i++)
        {
            var t = new Thread(() =>
            {
                evt.WaitOne();

                lock (sync)
                {
                    // critical section
                    Shared++;
                }
            });
            t.Start();
            threads.Add(t);
        }

        // make all threads start together
        evt.Set();

        foreach (var t in threads) t.Join();

        Console.WriteLine($"Actual = {Shared}, Expected = {n}");
    }
}