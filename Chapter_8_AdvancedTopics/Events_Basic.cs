using System.IO;
using System;

class Events_Basic
{
    public static void Main()
    {
        Engine engine = new Engine();
        engine.StatusChanged += OnStatusChange1;
        engine.StatusChanged += OnStatusChange1;

        engine.StatusChanged += OnStatusChange2;
        engine.StatusChanged += (Status status) =>
        {
            Console.WriteLine($"[Handler 3] Engine is now {status}");
        };

        engine.Start();
        engine.Stop();

        engine.StatusChanged -= OnStatusChange1;
        engine.Start();
        engine.Stop();
    }

    public static void OnStatusChange1(Status status)
    {
        Console.WriteLine($"[Handler 1] Engine is now {status}");
    }
    public static void OnStatusChange2(Status status)
    {
        Console.WriteLine($"[Handler 2] Engine is now {status}");
    }
}


public enum Status { Started, Stopped }
public delegate void StatusChange(Status status);

class Engine
{
    public event StatusChange StatusChanged;
    public void Start()
    {
        Console.WriteLine("Hello!");
        StatusChanged?.Invoke(Status.Started);
    }

    public void Stop()
    {
        Console.WriteLine("Bye!");
        StatusChanged?.Invoke(Status.Stopped);
    }
}