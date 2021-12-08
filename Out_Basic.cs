using System;

class Out_Basic{

    public static void Main(){

        // The out keyword is similar to the ref keyword. The difference is that a variable passed as 
        // an out argument does not have to be initialized before the method called, but the method 
        // taking an out parameter must assign a value to it before returning. The out keyword 
        // must be present both in the method definition and in the invocation of the method, before 
        // the argument

        // Returning an output value is useful in situations when a method needs to return more 
        // than one value, or when it needs to return a value but also information about whether 
        // the execution was successful or not.

        bool success = int.TryParse("10", out int result);

        Square(5, out int res);
        Console.WriteLine($"Square(5) = {res}");
    }

    public static void Square(int input, out int output) {

        // throws error - Use of unassigned out parameter 'output'  
        // int x = output;
        
        output = input * input;
    }
}