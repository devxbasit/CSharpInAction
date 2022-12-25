using System;
using System.Threading;

class ManualResetEventSlim_PingPongDemo
{
    public static void Main()
    {

        var ping = new ManualResetEventSlim(false);
        var pong = new ManualResetEventSlim(false);

        bool quit = false;

        // work 1

        ThreadPool.QueueUserWorkItem(_ =>
        {
            Console.WriteLine($"Ping Thread: {Thread.CurrentThread.ManagedThreadId}");

            while (!quit)
            {
                pong.Wait();
                pong.Reset();
                Console.WriteLine("Ping");
                Thread.Sleep(1000);
                ping.Set();
            }
        });

        // work 2
        ThreadPool.QueueUserWorkItem(_ =>
        {
            Console.WriteLine($"Pong Thread:  {Thread.CurrentThread.ManagedThreadId}");

            while (!quit)
            {
                ping.Wait();
                ping.Reset();
                Console.WriteLine("Pong");
                Thread.Sleep(1000);
                pong.Set();
            }
        });

        //both threads are blocked right now

        // ping waiting for pong.set (signal from pong)
        pong.Set();
        Console.ReadKey();
        quit = true;
    }
}