using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


class Thread_Example1
{
    public static void Main()
    {

        // Console.WriteLine("Starting Primes");
        // foreach (long n in new Primes(90))
        //     Console.Write($"n = {n}");
        // Console.WriteLine("End Primes");


        // *** Above blocking code fix
        // move the blocking code into a separate method so that we can
        // execute it in a new and separate thread

        // *** manually creating thread
        PrintThreadInfo(Thread.CurrentThread);
        Console.WriteLine("Start Primes");
        var t1 = new Thread(Worker);
        //t1.IsBackground = true;
        t1.Start();
        Console.WriteLine("Prime Calcultion is happening in background");


        // *** using thread pool
        ThreadPool.QueueUserWorkItem(Worker);

    }
    private static void Worker(object param)
    {
        PrintThreadInfo(Thread.CurrentThread);

        foreach (var n in new Primes(900000))
        {
            // Sleep is not recommended in production code because it prevents that thread from being reused
            //Thread.Sleep(100);
        }

        Console.WriteLine("Computation Ended!");
    }

    private static void PrintThreadInfo(Thread t)
    {
        var sb = new StringBuilder();
        var state = t.ThreadState;
        sb.Append($"Id:{t.ManagedThreadId} Name:{t.Name} State:{ state}");
        if ((state & (ThreadState.Stopped | ThreadState.Unstarted)) == 0)
        {
            sb.Append($"Priority:{t.Priority} IsBackground:{t.IsBackground}");
        }
        Console.WriteLine(sb.ToString());
    }
}


public class Primes : IEnumerable<long>
{
    public long Max { get; private set; }
    public Primes(long Max = long.MaxValue)
    {
        this.Max = Max;
    }

    // non generic method
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => ((IEnumerable<long>)this).GetEnumerator();

    // generic method
    public IEnumerator<long> GetEnumerator()
    {
        yield return 1;

        bool bFlag;
        long start = 2;
        while (start < Max)
        {
            bFlag = false;
            var number = start;
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    bFlag = true;
                    break;
                }
            }

            if (!bFlag)
            {
                yield return number;
            }

            start++;
        }
    }
}