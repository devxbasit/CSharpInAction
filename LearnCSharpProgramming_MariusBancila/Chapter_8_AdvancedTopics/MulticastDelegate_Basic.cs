using System.IO;
using System;

class MulticastDelegate_Basic
{
    public static void Main()
    {

        Engine engine = new Engine();
        engine.RegisterStatusChangeHandler(StatusChangeCallback1);
        engine.RegisterStatusChangeHandler(StatusChangeCallback3);
        engine.RegisterStatusChangeHandler(StatusChangeCallback2);

        engine.Start();
        engine.Stop();

        Console.WriteLine();
        Console.WriteLine("After UnregisterStatusChangeHandler");
        engine.UnregisterStatusChangeHandler(StatusChangeCallback1);

        engine.Start();
        engine.Stop();






    }

    public static void StatusChangeCallback1(Status status)
    {
        Console.WriteLine($"[Callback1] Engine is now {status}");
    }
    public static void StatusChangeCallback2(Status status)
    {
        Console.WriteLine($"[Callback2] Engine is now {status}");
    }
    public static void StatusChangeCallback3(Status status)
    {
        Console.WriteLine($"[Callback3] Engine is now {status}");
    }
}

public enum Status { Started, Stopped }
public delegate void StatusChange(Status status);

class Engine
{
    private StatusChange _statusChangeHandler;

    public void RegisterStatusChangeHandler(StatusChange handler)
    {
        // overloaded +=
        _statusChangeHandler += handler;
    }

    public void UnregisterStatusChangeHandler(StatusChange handler)
    {
        // overloaded -=
        _statusChangeHandler -= handler;
    }

    public void Start()
    {
        // do something 

        Console.WriteLine("Hello!");
        _statusChangeHandler?.Invoke(Status.Started);
    }

    public void Stop()
    {
        Console.WriteLine("Bye!");
        _statusChangeHandler?.Invoke(Status.Stopped);
    }
}