using System;
using System.Collections.Generic;
using System.Threading;

class ReturnValueFromThreadFunction
{
    public static void Main()
    {
        EventHandler<CalculateSumEventArgs> calculateSumHandler = new EventHandler<CalculateSumEventArgs>((sender, e) =>
        {
            Console.WriteLine($"Sum = {e.Sum} (result from {e.ThreadName})");
        });

        var threads = new List<Thread>();

        int numberOfThreads = 5;

        for (int i = 0; i < numberOfThreads; i++)
        {
            threads.Add(new Thread(new CalculateSumHelper(500000, calculateSumHandler).CalculateSum));
            threads[i].Name = $"Thread {i + 1}";
        }

        foreach (var thread in threads) thread.Start();
    }
}


public class CalculateSumHelper
{
    private int _max;
    private EventHandler<CalculateSumEventArgs> _callback;
    public CalculateSumHelper(int max, EventHandler<CalculateSumEventArgs> callback) => (this._max, this._callback) = (max, callback);

    public void CalculateSum()
    {

        Console.WriteLine($"{Thread.CurrentThread.Name} Starting...");

        var sum = 0;
        for (int i = 0; i <= _max; i++)
        {
            sum += i;
        }

        _callback?.Invoke(this, new CalculateSumEventArgs(sum, Thread.CurrentThread.Name));
    }
}


public class CalculateSumEventArgs : EventArgs
{
    public CalculateSumEventArgs(int sum, string threadName) => (this.Sum, this.ThreadName) = (sum, threadName);
    public int Sum { get; }
    public string ThreadName { get; }
}