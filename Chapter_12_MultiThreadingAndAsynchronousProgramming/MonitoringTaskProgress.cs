using System;
using System.Threading.Tasks;

class MonitoringTaskProgress
{
    public static void Main()
    {
        Load(new ConsoleProgress()).Wait();
    }
    public static async Task Load(IProgress<int> progress = null)
    {
        var steps = 30;

        for (int i = 0; i < steps; i++)
        {
            await Task.Delay(100);
            progress?.Report((i + 1) * 100 / steps);
        }
    }
}

public class ConsoleProgress : IProgress<int>
{
    public void Report(int value) => Console.Write($"{value}% \t");
}