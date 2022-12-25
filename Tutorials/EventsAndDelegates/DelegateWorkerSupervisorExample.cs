using System;
using System.Threading;


public delegate void TaskStarted(Worker worker, DateTime dt);
public delegate void TaskProgressUpdate(Worker worker, float progress);
public delegate int TaskCompleted(Worker worker, int cost);


class DelegateWorkerSupervisorExample
{

    public static void Main()
    {

        Worker worker1 = new Worker(1, "Generate Report");
        Supervisor supervisor = new Supervisor();

        worker1.ExecuteJob(supervisor.OnTaskStarted, supervisor.OnTaskProgressUpdate, supervisor.OnTaskCompleted);
    }
}



public class Supervisor
{
    public void OnTaskStarted(Worker worker, DateTime dt)
    {
        Console.WriteLine($"Supervisor: Worker({worker.WorkerId}) Started doing task({worker.Job}) at {dt.ToString()}");
    }

    public void OnTaskProgressUpdate(Worker worker, float progress)
    {
        Console.WriteLine($"Supervisor: Task Update from Worker({worker.WorkerId}). Task Progress: {progress}");
    }

    public int OnTaskCompleted(Worker worker, int cost)
    {
        Console.WriteLine("Supervisor: Worker Task completed");
        return worker.WorkerId == 1 ? cost * 3 : cost * 2;

    }
}


public class Worker
{

    // worker will notify Supervisor
    public int WorkerId { get; set; }
    public string Job { get; set; }

    public Worker(int workerId, string job) => (this.WorkerId, this.Job) = (workerId, job);

    public void ExecuteJob(TaskStarted taskStartedCallback, TaskProgressUpdate taskProgressUpdateCallback, TaskCompleted taskCompletedCallback)
    {

        Console.WriteLine("Worker: Starting Task.");
        taskStartedCallback(this, DateTime.Now);

        var totalCost = 0;
        var random = new Random();

        for (int i = 1; i <= 5; i++)
        {
            Thread.Sleep(300);

            totalCost += random.Next(1, 50);
            var progress = ((float)i / 5) * 100;
            Console.WriteLine("Worker: Updating about task progress.");

            taskProgressUpdateCallback(this, progress);
        }

        Console.WriteLine("Worker: Updating about task completion.");
        var rewardsPoints = taskCompletedCallback(this, totalCost);

        Console.WriteLine($"Worker: Task Completed, Reward Points: {rewardsPoints}");
    }
}