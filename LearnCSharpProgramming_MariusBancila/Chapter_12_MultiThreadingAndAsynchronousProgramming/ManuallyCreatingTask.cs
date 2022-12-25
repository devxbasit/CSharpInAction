using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

class ManuallyCreatingTask
{
    public static void Main()
    {

        var filename = "TestFile.txt";
        var contentLength = ReadLengthAsync(filename).Result;
        Console.WriteLine($"Content Length = {contentLength}");


        // The essential recommendation is to try splitting the long jobs into smaller units of work
        // that can be easily transformed into tasks

        // long running task - avoiding thread pool starvation
        var t = new Task(() => Thread.Sleep(300000), TaskCreationOptions.LongRunning);
        t.Start();

    }

    public static Task<int> ReadLengthAsync(string filename)
    {

        return Task.Run<int>(() =>
        {
            // below line will block the current thread
            var content = File.ReadAllText(filename);
            return content.Length;
        });
    }
}