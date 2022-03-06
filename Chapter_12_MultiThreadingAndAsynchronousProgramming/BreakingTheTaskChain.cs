using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

class BreakingTheTaskChain{
    public static void Main() {

        // The return type of an async method must be void, Task, Task<T>,
        // a task-like type, IAsyncEnumerable<T>, or IAsyncEnumerator<T>

        FireAndForgetDemo();
        Console.WriteLine("Breaking the Task Chain");

    }
    public static async void FireAndForgetDemo()
    {
        var len = await Task<int>.Run(() =>
        {
            return 10;
        });

        Console.WriteLine($"Len = { len }");

        // But remember, when you break the task chain, you lose the possibility to know whether
        // the operation will ever complete or fail.
    }
}