using System;
using System.IO;
using System.Runtime.ExceptionServices;

class RethrowExceptionsLater
{
    public static void Main()
    {
        ReThrowLater();
    }


    public static void ReThrowLater()
    {

        ExceptionDispatchInfo exceptionDispatchInfo = null;
        try
        {
            var x = 2 / 0;
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

        // rethrow
        if (exceptionDispatchInfo != null) exceptionDispatchInfo.Throw();


    }
}