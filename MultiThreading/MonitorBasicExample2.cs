using System;
using System.Collections.Generic;
using System.Threading;

class MonitorBasicExample2
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
    }
}

public class PrintNumbers
{
    private static readonly object _lockPrintNumbers = new Object();

    public void PrintSomeNumbers()
    {

        // The input must be false. The output is true if the lock is acquired; otherwise, the output is false. 
        // The output is set even if an exception occurs during the attempt to acquire the lock. 
        // It will ArgumentException if the input to lockTaken is true.
        bool _isLockTaken = false;

        try
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} trying to enter critical section.");
            Monitor.Enter(_lockPrintNumbers, ref _isLockTaken);
            Console.WriteLine($"{Thread.CurrentThread.Name} entered into the critical section.");

            for (var i = 0; i < 10; i++)
            {
                Console.Write($"{i}, ");
            }

            Console.WriteLine();
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