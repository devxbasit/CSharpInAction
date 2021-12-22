using System.IO.Enumeration;
using System.Diagnostics;
using System;

class ExceptionalHandling_Basic{

    public static void Main(){

        // The exception propagates up, and should be handled at a higher level
        
        try {
            DoSomeWork(42);
        }
        catch (ArgumentNullException e) {
            Console.WriteLine($"Null Argument: {e.Message}");

        } 
        catch(ArgumentException e) {
            Console.WriteLine($"Wrong Argument: {e.Message}");
        }
        catch(Exception e) {
            Console.WriteLine($"Error: {e.Message}");
        } 
        finally 
        {
            Console.WriteLine("Clean Up code here");
        }
    }

    public static void DoSomeWork(object o){

        if (o is null) {
            throw new ArgumentNullException();
        }

        if (!(o is string)) {
            throw new ArgumentException("A string is expected");
        }
    }
}