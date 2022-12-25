#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.CompilerServices;

class EventHandlerWorkerSupervisorExample
{

    public static void Main()
    {
        // see first delegate other examples

        // ***
        // event should be raised in a separate function declared as protected virtual - should not be accessible from outside
        // naming convention - add "Handler" after delegate name

        Worker worker = new Worker();
        Supervisor supervisor = new Supervisor();

        worker.TaskStartedHandler += new EventHandler((sender, e) =>
        {
            Console.WriteLine("Listener: Worker started doing task");
        });

        worker.TaskStartedHandler += (sender, e) =>
        {
            Console.WriteLine("Subscriber: Worker started doing task");
        };


        worker.TaskStartedHandler += supervisor.TaskStartedHandler;
        worker.TaskProgressUpdateHandler += new EventHandler<TaskProgressUpdateEventArgs>(supervisor.TaskProgressUpdateHandler);
        worker.TaskCompletedHandler += new EventHandler<DateTime>(supervisor.TaskCompletedHandler);

        worker.TaskCompletedHandler += new EventHandler<DateTime>((sender, dt) =>
        {
            Console.WriteLine($"SomeOtherSubscriber: Worker is done with work");
        });

        worker.ExecuteJob();

    }
}

public class Supervisor
{
    public void TaskStartedHandler(object? sender, EventArgs e)
    {
        Console.WriteLine("Supervisor: Worker Started Doing Task.");
    }

    public void TaskProgressUpdateHandler(object? sender, TaskProgressUpdateEventArgs e)
    {
        Console.WriteLine($"Supervisor: Task progress update, Task Progress: {e.progress} ");
    }

    public void TaskCompletedHandler(object? sender, DateTime dt)
    {
        Console.WriteLine($"Supervisor: Task Completed At {dt.ToString()}");
    }
}

public class Worker
{
    private event EventHandler _taskStartedHandler;
    public event EventHandler TaskStartedHandler
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        add
        {
            _taskStartedHandler += value;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        remove
        {
            _taskStartedHandler -= value;
        }
    }


    public event EventHandler<TaskProgressUpdateEventArgs> TaskProgressUpdateHandler;
    public event EventHandler<DateTime> TaskCompletedHandler;


    public void ExecuteJob()
    {

        OnTaskStarted();

        for (int i = 1; i <= 5; i++)
        {
            Thread.Sleep(300);
            var progress = ((float)i / 5) * 100;
            OnTaskProgressUpdate(progress);
        }

        OnTaskCompleted();
    }

    protected virtual void OnTaskStarted()
    {
        Console.WriteLine("Worker: Task Started.");
        _taskStartedHandler?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnTaskProgressUpdate(float progress)
    {
        Console.WriteLine($"Worker: Updating about task progress. Task Progress {progress}");
        TaskProgressUpdateHandler?.Invoke(this, new TaskProgressUpdateEventArgs(progress));
    }

    protected virtual void OnTaskCompleted()
    {
        Console.WriteLine("Worker: Task completed");
        TaskCompletedHandler?.Invoke(this, DateTime.Now);
    }
}

public class TaskProgressUpdateEventArgs : EventArgs
{
    public float progress;
    public TaskProgressUpdateEventArgs(float progress) => this.progress = progress;
}