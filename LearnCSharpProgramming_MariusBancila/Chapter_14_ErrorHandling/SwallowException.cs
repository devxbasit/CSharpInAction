using System;

class SwallowException
{
    public static void Main()
    {
        try
        {
            Crash();
            Console.WriteLine("Program will run normally");

        }
        catch (Exception err)
        {
            Console.WriteLine("Hello");
            Console.WriteLine(err.Message);
        }

        Console.WriteLine("World");
    }

    public static void Crash()
    {
        try
        {
            throw new Exception("Error message");
        }
        catch (Exception)
        {
            // swallow
        }
    }
}