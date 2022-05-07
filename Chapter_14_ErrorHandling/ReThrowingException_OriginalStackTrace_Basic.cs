using System;
using System.IO;

class ReThrowingException_OriginalStackTrace_Basic
{
    public static void Main()
    {
        // https://docs.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2015/code-quality/ca1032-implement-standard-exception-constructors?view=vs-2015&redirectedfrom=MSDN
        ReadAllText("");
    }

    public static string ReadAllText(string filename)
    {
        try
        {
            return File.ReadAllText(filename);
        }
        catch (Exception err)
        {
            Log(err.Message);

            // throw; rethrows the original exception and preserves its original stack trace.

            throw;

            // throw ex; throws the original exception but resets the stack trace, destroying all stack trace information until your catch block
            //throw err;



            //throw new Exception("") 



            // The throw statement is not followed by any parameter, but it is the equivalent of
            // specifying the same exception received in the catch block.

            // Unless the err reference is changed to point to a different object, the two statements are
            // equivalent and have the big advantage of preserving the original stack that caused the
            // error.

            // If we throw a different exception object, the original stack is not a part of the exception
            // being thrown, and this is the reason why innerException exists.
            //throw new IOException("message", err);

        }

    }

    public static void Log(string message)
    {
        // log
    }
}

