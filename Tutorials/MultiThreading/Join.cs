using System;
using System.Threading;
using System.Collections.Generic;

class Join
{
    public static void Main()
    {
        try
        {

            Thread.CurrentThread.Name = "Main Thread";
            Console.WriteLine($"*** {Thread.CurrentThread.Name} Started...");

            var t1 = new Thread(SayHello);
            var t2 = new Thread(SayHello);
            var t3 = new Thread(SayHello);
            var t4 = new Thread(SayHello);

            (t1.Name, t2.Name, t3.Name, t4.Name) = ("Thread1", "Thread2", "Thread3", "Thread4");

            // will throw thread state exception
            // t1.Join();

            if (t1.IsAlive) t1.Join();

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            if (t1.IsAlive) t1.Join();
            if (t2.IsAlive) t2.Join();
            if (t3.IsAlive) t3.Join();
            if (t4.IsAlive) t4.Join();

            // Main Thread will wait for all thread
            Console.WriteLine($"*** {Thread.CurrentThread.Name} Ended.");
        }
        catch (ThreadStateException ex)
        {
            Console.WriteLine($"Exception - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception - {ex.Message}");
        }
    }

    public static void SayHello()
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} Started...");
        Console.WriteLine($"{Thread.CurrentThread.Name}: Hello");
        Thread.Sleep(2000);
        Console.WriteLine($"{Thread.CurrentThread.Name} Finished Doing Work.");
    }
}
