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
            await WorkForever1Async(tok);
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
}