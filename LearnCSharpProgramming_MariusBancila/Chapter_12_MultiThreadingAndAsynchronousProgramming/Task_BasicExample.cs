using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

class Task_BasicExample
{
    public static void Main()
    {
        string f = "TestFile.txt";
        Task<int> len = ReadLengthAsync(f);

        // .Result will block the current thread
        Console.WriteLine($"Content Length = {len.Result}");


        Func<int, int, Task<int>> adder =
             async (a, b) => await AddAsync(a, b);

        Task res = WriteEmptyJsonObject(f);
    }

    public static async Task<int> ReadLengthAsync(string filename)
    {
        string content = await File.ReadAllTextAsync(filename);
        int len = content.Length;

        // expected return value  type -> Task<int>
        // actual return value type -> int

        return len;
        
    }

    public static Task<int> AddAsync(int a, int b)
    {
        // Task<int> t = Task.Run<int>(() =>
        // {
        //     return a + b;
        // });

        // return t;

        return Task.FromResult(a + b);
    }

    public static Task WriteEmptyJsonObject(string filename) {

        // Synchronous implementation to Asynchronous method

        File.WriteAllText(filename, "{}");

        // The CompletedTask property is created only once for the entire application
        // domain; therefore, it is extremely lightweight and should not be any cause for concern
        // regarding performance.
        return Task.CompletedTask;
    }



}