using System;
using System.Collections.Generic;
using System.Threading;


class WaitHandle_BasicExample
{
    public static void Main()
    {
        WaitMultipleDemo();
    }

    public static void WaitMultipleDemo()
    {

        var one = new ManualResetEvent(false);
        var two = new ManualResetEvent(false);

        ThreadPool.QueueUserWorkItem(_ =>
        {
            Thread.Sleep(20000);

            // do some work

            one.Set();
        });


        ThreadPool.QueueUserWorkItem(_ =>
        {
            Thread.Sleep(1000);

            // do some work

            two.Set();
        });


        int singled = WaitHandle.WaitAny(new WaitHandle[] { one, two }, 3000);

        switch (singled)
        {
            case 0:
                Console.WriteLine("One was set!");
                break;

            case 1:
                Console.WriteLine("Two was set!");
                break;

            case WaitHandle.WaitTimeout:
                Console.WriteLine("Time expired!");
                break;
        }
    }
}