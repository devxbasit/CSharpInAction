using System;

class Delegate_Basic
{
    public static void Main()
    {
        /*
            In languages such as C and C++, a callback is simply a function pointer (that is, the address
            of a function). However, in .NET, callbacks are strongly-typed objects that hold not only
            the reference to one or more methods but also the information about their parameters and
            return type. In .NET and C#, callbacks are represented by delegates.

            A delegate is defined using the delegate keyword. The declaration looks like a function
            signature, but the compiler actually introduces a class that can hold references to methods
            whose signatures match the signature of the delegate. A delegate can hold references to
            either static or instance methods.
        */

        Engine engine = new Engine();
        engine.RegisterStatusChangeHandler(StatusChangeCallback);

        engine.Start();
        engine.Stop();
    }

    public static void StatusChangeCallback(Status status)
    {
        Console.WriteLine($"Engine is now {status}");
    }
}

public enum Status { Started, Stopped }
public delegate void StatusChange(Status status);

class Engine
{
    private StatusChange _statusChangeHandler;

    public void RegisterStatusChangeHandler(StatusChange handler)
    {
        _statusChangeHandler = handler;
    }

    public void UnregisterStatusChangeHandler()
    {
        _statusChangeHandler = null;
    }

    public void Start()
    {
        // do something 
        Console.WriteLine("Hello!");

        if (_statusChangeHandler != null)
        {
            _statusChangeHandler(Status.Started);
            // _statusChangeHandler.Invoke(Status.Started);
           
            /*
                The class created by the compiler contains three methods—Invoke() (used to invoke
                the callbacks in a synchronous manner), BeginInvoke(), and EndInvoke() (used
                to invoke the callbacks in an asynchronous manner). 
            */
            
        }
    }

    public void Stop()
    {
        // do something 
        Console.WriteLine("Bye!");

        if (_statusChangeHandler != null)
            _statusChangeHandler(Status.Stopped);
    }
}
