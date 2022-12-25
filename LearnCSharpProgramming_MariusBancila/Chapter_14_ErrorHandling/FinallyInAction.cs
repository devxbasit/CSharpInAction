using System;
using System.IO;

class FinallyInAction
{
    public static void Main()
    {
        // finally allows expression of the portion of code that must be
        // invoked after the try block, regardless of whether an exception has occurred or not.


        M1();


        // Another common use for the try..finally combo is to ensure that a resource has
        // been correctly disposed, and C# has made of this pattern a keyword, which is the using
        // statement.

    }

    public static void M1()
    {
        try
        {
            M2();
        }
        catch (Exception)
        {
            // ***
            Console.WriteLine($"catch in {System.Reflection.MethodBase.GetCurrentMethod().Name}");
        }
        finally
        {
            Console.WriteLine($"finally in {System.Reflection.MethodBase.GetCurrentMethod().Name}");
        }
    }

    public static void M2()
    {
        try
        {
            M3();
        }
        catch (Exception)
        {
            Console.WriteLine($"catch in {System.Reflection.MethodBase.GetCurrentMethod().Name}");
        }
        finally
        {
            Console.WriteLine($"finally in {System.Reflection.MethodBase.GetCurrentMethod().Name}");
        }
    }

    public static void M3()
    {
        try
        {
            // The finally block can be specified even without any catch block, meaning that
            // any exception will be bounced back to the call chain, but the code specified inside the
            // finally block will be executed in any case right after the try block.

            Crash();
        }
        finally
        {
            Console.WriteLine($"finally in {System.Reflection.MethodBase.GetCurrentMethod().Name}");
        }
    }

    public static void Crash()
    {
        throw new Exception();
    }
}
