using System.Text.RegularExpressions;
using System;

class Regex_Basic
{
    public static void Main()
    {
        var pattern = @"(\d{4})-(1[0-2]|0[1-9]|[1-9]{1})-(3[01]|[12][0-9]|0[1-9]|[1-9]{1})";

        // using static method
        /*
            If you need to match a pattern only once or a few times, then you could use the static
            methods as they are simpler.
        */
        bool success = Regex.IsMatch("3-1-2022", pattern);
        Console.WriteLine($"success = {success}");


        // using non static method 
        /*
            if you match the same pattern tens of thousands
            of times or more, using an instance of the class and calling the non-static members is
            potentially faster. For most common usage, this is not the case. 
        */
        var regex = new Regex(pattern);
        success = regex.IsMatch("3-1-2022");
        Console.WriteLine($"success = {success}");

    }
}