using System;

class FuncActionBasic
{
    public static void Main()
    {
        // See first DelegateWorkerSupervisorExample.cs

        Func<int, int, int> Sum = (x, y) => x + y;
        Action<string> SaySomething = delegate (string msg) { Console.WriteLine(msg); };
        Predicate<int> IsEven = (x) => x % 2 == 0;

        Console.WriteLine(Sum?.Invoke(1, 2));
        SaySomething?.Invoke("Hello");
        Console.WriteLine(IsEven?.Invoke(2));

        Worker worker = new Worker();
        Supervisor supervisor = new Supervisor();

        worker.ExecuteJob(supervisor.OnTaskStarted);
    }
}

public class Supervisor
{

    public void OnTaskStarted(Worker worker, DateTime dt)
    {
        Console.WriteLine($"Supervisor: Task started by worker at {dt.ToString()}");
    }
}


public class Worker
{

    public void ExecuteJob(Action<Worker, DateTime> taskStarted)
    {

        Console.WriteLine("Worker: Starting Task");
        taskStarted?.Invoke(this, DateTime.Now);
    }
}