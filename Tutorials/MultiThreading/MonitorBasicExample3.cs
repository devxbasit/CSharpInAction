using System;
using System.Collections.Generic;
using System.Threading;

class MonitorBasicExample3
{
    public static void Main()
    {
        var task = new PrintNumbers();
        var threads = new List<Thread>(){
            new(task.PrintSomeNumbers) {Name = "Thread 1"},
            new(task.PrintSomeNumbers) {Name = "Thread 2"},
            new(task.PrintSomeNumbers) {Name = "Thread 3"},
            new(task.PrintSomeNumbers) {Name = "Thread 4"},
        };

        foreach (Thread thread in threads) thread.Start();

        foreach (Thread thread in threads) thread.Join();
    }
}

public class PrintNumbers
{
    private static readonly object _lockPrintNumbers = new Object();

    public void PrintSomeNumbers()
    {
        TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
        bool _isLockTaken = false;

        try
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} trying to enter critical section.");
            Monitor.TryEnter(_lockPrintNumbers, timeout, ref _isLockTaken);

            if (_isLockTaken)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} entered into the critical section.");

                for (var i = 0; i < 10; i++)
                {
                    Console.Write($"{i}, ");
                }
                Thread.Sleep(700);

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} lock was not acquired.");
            }
        }
        finally
        {
            if (_isLockTaken)
            {
                Monitor.Exit(_lockPrintNumbers);
                Console.WriteLine($"{Thread.CurrentThread.Name} exit from the critical section.");
            }
        }
    }
}
