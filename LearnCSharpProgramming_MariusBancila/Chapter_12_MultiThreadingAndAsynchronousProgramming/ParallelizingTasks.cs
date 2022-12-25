using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;

class ParallelizingTasks
{
    public static void Main()
    {

        // download all images in parallel and then process
        NeedAll().Wait();

        // Wait for the first download, so that we can start processing it, but still download in parallel
        NeedAny().Wait();

    }


    public static async Task NeedAll()
    {
        var uri = "https://picsum.photos/200";

        // The use of Enumerable.Range is a nice way to repeat an action for the given number of times.
        Task<byte[]>[] tasks = Enumerable.Range(0, 10)
            .Select(_ => GetResourceAsync(uri))
            .ToArray();

        // The task obtained from the WhenAll method cannot be used to retrieve the results, but
        // it guarantees that we can access the Result properties for all the tasks.
        Task allTask = Task.WhenAll(tasks);

        try
        {
            await allTask;
        }
        catch (Exception)
        {
            Console.WriteLine("One or more downloads failed.");
        }

        foreach (var completedTask in tasks)
        {
            Console.WriteLine($"New Image: {completedTask.Result.Length}");
        }
    }


    public static async Task NeedAny()
    {
        var sw = new Stopwatch();
        sw.Start();

        var uri = "https://picsum.photos/200";
        Task<byte[]>[] tasks = Enumerable.Range(0, 10)
            .Select(_ => GetResourceAsync(uri))
            .ToArray();

        while (tasks.Length > 0)
        {
            await Task.WhenAny(tasks);

            // ***
            // combine WhenAll, WhenAny

            // get as many downloaded images as possible in no more than 100 milliseconds,
            // In other words, we are asking to wait for any task (at least one) but not before 100
            // milliseconds. The while loop will repeat the operation, as we did previously, by
            // consuming all the remaining tasks

            //await Task.WhenAll(Task.Delay(100), Task.WhenAny(tasks));

            var elapsed = sw.ElapsedMilliseconds;
            var completed = tasks.Where(t => t.IsCompleted)
                .ToArray();

            foreach (var completedTask in completed)
                Console.WriteLine($"{elapsed} New Image : {completedTask.Result.Length}");

            tasks = tasks.Where(t => !t.IsCompletedSuccessfully)
                .ToArray();
        }
    }

    public static async Task<byte[]> GetResourceAsync(string uri)
    {
        using var client = new HttpClient();
        using var response = await client.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsByteArrayAsync();
    }
}