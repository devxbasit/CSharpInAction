using System.Collections.Generic;
using System;

class ExtensionMethod_Basic
{    
    public static void Main()
    {
        // Extension Methods
        // They must be declared as a static method of a static, non-nested, non-generic class

        string s = "Hello";
        Console.WriteLine($"s.Reverse() = {s.Reverse()}");

        var exception = new InvalidOperationException(
            "An invalid operation occurred",
            new NotSupportedException(
                "The operation is not supported",
                new InvalidCastException("Cannot apply cast!")));

        Console.WriteLine(exception.AllMessages());
        Console.WriteLine();
        Console.WriteLine(exception.AllMessages(true));
    }   
}

static class StringExtension
{
    public static string Reverse(this string s)
    {
        var charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

static class ExceptionExtension {
    
    public static string AllMessages(this Exception exception, bool reverse = false) {
        var messages = new List<string>();
        var ex = exception;
        
        while (ex != null) {
            messages.Add(ex.Message);
            ex = ex.InnerException;
        }

        if (reverse) messages.Reverse();

        return string.Join(Environment.NewLine, messages);
    }
}
