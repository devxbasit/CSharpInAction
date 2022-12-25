using System;
using System.Threading;

class ThreadBasicExample
{

    public static void Main()
    {

        ThreadStart threadStartDelegate = new ThreadStart(DoWork);
        ParameterizedThreadStart parameterizedThreadStartDelegate = new ParameterizedThreadStart(DoWorkWithParam);

        Thread t1 = new Thread(threadStartDelegate);
        Thread t2 = new Thread(parameterizedThreadStartDelegate);

        t1.Name = "Thread1";
        t2.Name = "Thread2";

        t1.Start();

        // not recommended way of passing data.
        t2.Start(10);

        // new Thread(DoWork).Start();
        // new Thread(DoWorkWithParam).Start(10);
    }

    public static void DoWork()
    {
        for (var i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
        }
    }

    public static void DoWorkWithParam(object len)
    {
        for (var i = 1; i <= (int)len; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
        }
    }
}