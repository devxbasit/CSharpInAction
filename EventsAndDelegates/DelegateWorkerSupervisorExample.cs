using System;
using System.Threading;


public delegate void TaskStarted(Worker worker, DateTime dt);
public delegate void TaskProgressUpdate(Worker worker, byte progress);
public delegate int TaskCompleted(Worker worker, int cost);



class DelegateWorkerSupervisorExample
{

    public static void Main()
    {

        Worker worker1 = new Worker(1, "Generate Report");
        Supervisor supervisor = new Supervisor();

        worker1.ExecuteJob(supervisor.WorkerTaskStarted, supervisor.WorkerTaskProgressUpdate, supervisor.WorkerTaskCompleted);
    }
}



public class Supervisor
{
    public void WorkerTaskStarted(Worker worker, DateTime dt)
    {
        Console.WriteLine($"Supervisor: Worker({worker.WorkerId}) Started doing task({worker.Job}) at {dt.ToString()}");
    }

    public void WorkerTaskProgressUpdate(Worker worker, byte progress)
    {
        Console.WriteLine($"Supervisor: Task Update from Worker({worker.WorkerId}). Task Progress: {progress}");
    }

    public int WorkerTaskCompleted(Worker worker, int cost)
    {
        Console.WriteLine("Supervisor: Worker Task completed");

        var rewardsPoints = cost * 2;

        if (worker.WorkerId == 1)
        {
            return rewardsPoints + 100;
        }

        return rewardsPoints;
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

        var cost = 0;
        var random = new Random();

        for (int i = 1; i <= 10; i++)
        {

            Thread.Sleep(300);
            cost += random.Next(1, 50);
            Console.WriteLine("Worker: Updating about task progress.");
            taskProgressUpdateCallback(this, ((byte)(i * 10)));
        }

        Console.WriteLine("Worker: Updating about task completion.");
        var rewardsPoints = taskCompletedCallback(this, cost);

        Console.WriteLine($"Worker: Task Completed, Reward Points: {rewardsPoints}");
    }
}