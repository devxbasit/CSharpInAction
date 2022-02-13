using System;
using System.Threading;
using System.Collections.Generic;

class Interlocked_Example1
{
    public static void Main()
    {
        CriticalSectionDemo obj1 = new CriticalSectionDemo();
        InterLockedDemo obj2 = new InterLockedDemo();

        obj1.DoSomeWork();
        obj2.DoSomeWork();
    }
}

class CriticalSectionDemo
{
    private int _shared;
    public void DoSomeWork()
    {
        List<Thread> threads = new List<Thread>();

        for (int i = 0; i < 9999; i++)
        {
            var t = new Thread(IncrementShared);
            t.Start();
            threads.Add(t);
        }

        foreach (var thread in threads) thread.Join();

        Console.WriteLine($"Shared = {_shared}");
    }
    public void IncrementShared()
    {
        int temp = _shared;

        // mock OS context switch
        Thread.Sleep(50);

        _shared = temp + 1;
    }
}

class InterLockedDemo
{
    private int _shared;
    public void DoSomeWork()
    {
        List<Thread> threads = new List<Thread>();

        for (int i = 0; i < 9999; i++)
        {
            var t = new Thread(IncrementShared);
            t.Start();
            threads.Add(t);
        }

        foreach (var thread in threads) thread.Join();

        Console.WriteLine($"Shared = {_shared}");
    }
    public void IncrementShared()
    {
        Thread.Sleep(50);
        Interlocked.Increment(ref _shared);
    }
}