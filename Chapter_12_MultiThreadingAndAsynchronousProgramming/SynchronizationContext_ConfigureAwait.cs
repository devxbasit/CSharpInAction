using System;
using System.Threading;
using System.Threading.Tasks;

class ConfigureAwait
{
    public static async Task Main()
    {
        // https://www.youtube.com/watch?v=avhLfcgIwbg
        // https://www.c-sharpcorner.com/article/understanding-synchronization-context-task-configureawait-in-action/
        // https://blog.stephencleary.com/2017/03/aspnetcore-synchronization-context.html
        // https://devblogs.microsoft.com/dotnet/configureawait-faq/
        // if set to true, code before and after(continuation) "await" will run on same thread
        // UI Developers should set it to true (two different threads -> update same ui component) 
        // Library Developers should set it to false

        // By using ConfigureAwait(false) this can be prevented and deadlocks can be avoided.

        string message;
        message = await DoSomeWork().ConfigureAwait(continueOnCapturedContext: true);

        // message = await DoSomeWork().ConfigureAwait(continueOnCapturedContext: true);

        // continuation code 
        Console.WriteLine(message);
    }


    public static Task<string> DoSomeWork()
    {
        Task.Delay(1000);
        return Task.Run<string>(() =>
        {
            return "Hello!";
        });
    }


}