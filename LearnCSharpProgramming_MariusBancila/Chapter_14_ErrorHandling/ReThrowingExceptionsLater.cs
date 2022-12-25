using System;
using System.IO;
using System.Runtime.ExceptionServices;

class ReThrowingExceptionsLater
{
    public static void Main()
    {
        //https://stackoverflow.com/questions/45723327/whats-the-point-of-passing-exceptiondispatchinfo-around-instead-of-just-the-exc

        //an exception's StackTrace changes when it's re-thrown. the purpose of ExceptionDispatchInfo.Capture is to capture a potentially mutating exception's StackTrace at a point in time

        ReThrowLater();

    }


    public static void ReThrowLater()
    {
        ExceptionDispatchInfo exceptionDispatchInfo = null;

        try
        {
            throw new DivideByZeroException();
        }
        catch (Exception err)
        {
            // In certain cases, you may want to save the exception captured by the catch block and
            // rethrow it later. By simply throwing the captured exception (throw err), the captured stack would be
            // different and less useful. If you need to preserve the stack where the exception was initially
            // captured, you can use the ExceptionDispatchInfo class

            exceptionDispatchInfo = ExceptionDispatchInfo.Capture(err);
        }

        // do something that you cannot do in the catch block
        Console.WriteLine("Hello!");

        // rethrow
        if (exceptionDispatchInfo != null) exceptionDispatchInfo.Throw();
    }
}