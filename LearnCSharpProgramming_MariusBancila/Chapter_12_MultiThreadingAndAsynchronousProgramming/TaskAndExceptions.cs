using System;
using System.Threading;
using System.Threading.Tasks;

class TaskAndExceptions
{
    public static void Main()
    {
        // CrashBeforeAsync();
        // CrashAfterAsync();

        // HandleCrashBeforeAsync();
        //HandleCrashAfterAsync();

        var t = HandleCrashAfterAsync2();
        Console.WriteLine(t.Result);
    }

    public static Task<int> CrashBeforeAsync()
    {
        throw new Exception();
    }

    public static Task<int> CrashAfterAsync()
    {
        return Task.FromResult(0)
                .ContinueWith<int>(t =>
                {
                    throw new Exception();
                    // throw new OverflowException();
                });


        // similar to what we saw with FromResult<T>, a new Task is created, but this time, its
        // state is initialized to faulted and it contains the desired exception.

        // return Task.FromException<int>(new Exception());
    }


    public static Task<int> HandleCrashBeforeAsync()
    {

        Task<int> resultTask;

        try
        {
            resultTask = CrashBeforeAsync();
        }
        catch (Exception) { throw; }

        return resultTask;
    }

    public static async Task<int> HandleCrashAfterAsync()
    {

        Task<int> resultTask;
        int result;

        try
        {
            result = await CrashAfterAsync();
        }
        catch (Exception) { throw; }

        return result;
    }

    public static Task<int> HandleCrashAfterAsync2()
    {

        // Whenever you want to handle the exceptions and resolve them immediately, you may
        // want to use the continuations instead of the await keyword

        Task<int> resultTask = CrashAfterAsync();

        try
        {
            return resultTask.ContinueWith<int>(t =>
            {
                if (t.IsCompletedSuccessfully) return t.Result;

                if (t.Exception.InnerException is OverflowException) return -1;

                throw t.Exception.InnerException;
            });
        }
        catch (Exception) { throw; }
    }
}