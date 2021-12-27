using System.Threading.Tasks;
using System.Collections.Concurrent;
using System;

class BlockingCollection_Example
{
    public static void Main()
    {
        Demo();
    }

    public static async void Demo()
    {
        using var bc = new BlockingCollection<int>();

        using var producer = Task.Run(() =>
        {
            int a = 1, b = 1;
            bc.Add(a);
            bc.Add(b);

            for (int i = 0; i < 50; i++)
            {
                int c = a + b;
                bc.Add(c);
                Console.WriteLine($"Producer: Add({c})");
                a = b;
                b = c;
            }
            bc.CompleteAdding();
        });


        using var consumer1 = Task.Run(() =>
        {
            try
            {
                while (true)
                {
                    Console.WriteLine($"[Consumer 1] {bc.Take()}");
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("[Consumer 1] Collection Completed");
            }
            Console.WriteLine($"[Consumer 1] Work Done");
        });

        using var consumer2 = Task.Run(() =>
        {
            foreach (var n in bc.GetConsumingEnumerable())
            {
                Console.WriteLine($"[Consumer 2] {n}");
            }

            Console.WriteLine($"[Consumer 2] Work Done");
        });

        await Task.WhenAll(producer, consumer1, consumer2);
    }
}
