using System;
using System.Reflection;

class DelegateInAction
{
    public static void Main()
    {
        var supervisor = new Supervisor();

        WorkDoneHandler workDone = new WorkDoneHandler(supervisor.WorkDone);

        // both are same. Invoke is flexible, we can perform null checks
        workDone?.Invoke(1);
        if (workDone is not null) workDone(1);


        object target = workDone.Target;
        MethodInfo methodInfo = workDone.GetMethodInfo();
        Delegate[] invocationList = workDone.GetInvocationList();


        Console.WriteLine($"target = {target}");
        Console.WriteLine($"methodInfo = {methodInfo}");

        Console.WriteLine($"InvocationList length = {invocationList.Length}");
        foreach (var item in invocationList)
        {
            Console.WriteLine($"invocationList item = {item}");
            item.DynamicInvoke(1);
        }
    }

    public delegate int WorkDoneHandler(int timeTaken);
}


public class Supervisor
{
    public int WorkDone(int timeTaken)
    {
        Console.WriteLine($"Work Done in {timeTaken} second/s");
        var wages = timeTaken * 2;
        return wages;
    }
}