using System;

class Event_Example1
{
    public static void Main()
    {
        // see delegate, multicast delegate example first
        // Events are syntactic sugar that help with registration and removal of callbacks

        /*
            proper implementation of the event's pattern (used throughout the
            entire .NET Framework) is to have two arguments:
    
            • The first argument is System.Object, which holds a reference to the object that
            generated the event. It is up to the client being called to use this reference or not.

            • The second argument is of a type derived from System.EventArgs, which holds
            all of the event-related information.
        */

        Engine engine = new Engine();

        // register callback methods             
        engine.StatusChanged += OnStatusChange1;

        engine.Start();
        engine.Stop();
    }

    public static void OnStatusChange1(object sender, EngineEventArgs args)
    {
        Console.WriteLine($"Engine is now {args.Status}");
    }
}

public enum Status { Started, Stopped }
public delegate void StatusChange(object sender, EngineEventArgs args);

public class Engine
{
    public event StatusChange StatusChanged;

    public void Start()
    {
        /*
            Where did the Invoke() method come from? Behind the scenes, when
            you declare a delegate type, the compiler generates a sealed class derived from System.
            MulticastDelegate that in turn is derived from System.Delegate. These are
            system types that you are not allowed to derive explicitly from.
        */
        StatusChanged?.Invoke(this, new EngineEventArgs(Status.Started));
    }

    public void Stop()
    {
        StatusChanged?.Invoke(this, new EngineEventArgs(Status.Stopped));
    }
}

public class EngineEventArgs : EventArgs
{
    public Status Status { get; private set; }
    public EngineEventArgs(Status s)
    {
        Status = s;
    }
}
