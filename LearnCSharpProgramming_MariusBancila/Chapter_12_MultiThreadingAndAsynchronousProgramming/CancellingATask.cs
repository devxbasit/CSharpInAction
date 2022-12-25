using System;
using System.Threading;
using System.Threading.Tasks;

class CancellingATask
{
    public static void Main()
    {
        Task t = CancellingTaskDemo();
        t.Wait();
    }

    public static async Task CancellingTaskDemo()
    {
        CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
        var tok = cts.Token;
        try
        {
            // await WorkForever1Async(tok);    
            //await WorkForever2Async(tok);
            await WorkForever3Async(tok);

            Console.WriteLine("let's Continue");
        }
        catch (TaskCanceledException err) { Console.WriteLine(err.Message); }

    }

    public static async Task WorkForever1Async(CancellationToken ct = default(CancellationToken))
    {
        while (true)
        {
            await Task.Delay(5000, ct);
        }
    }

    public static Task WorkForever2Async(CancellationToken ct = default(CancellationToken))
    {
        // Another possibility is when a worker is executing only synchronous code and still needs to
        // be canceled
        while (true)
        {

            Thread.Sleep(5000);
            if (ct.IsCancellationRequested) return Task.FromCanceled(ct);
        }

        return Task.CompletedTask;
    }

    public static async Task WorkForever3Async(CancellationToken ct = default(CancellationToken))
    {
        // The third and final case is when you don't want to throw any exception, but just to return
        // from the execution:

        while (true)
        {
            // In this case, we carefully avoided propagating CancellationToken to the underlying
            // calls [ Task.Delay(milliseconds, cancellationToken) ], because, by using await, it would have triggered the exception.

            await Task.Delay(5000);
            if (ct.IsCancellationRequested) return;
        }
    }
}