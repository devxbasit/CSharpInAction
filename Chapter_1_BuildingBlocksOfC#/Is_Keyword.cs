using System.ComponentModel;
using System;

class Is_Keyword {
    public static void Main() {

        string msg = null;

        if (msg is null) 
            msg = "Hello Basit";
        
        if (msg is not null)
            Console.WriteLine($"msg = {msg}");

        if (msg is string)
            Console.WriteLine($"msg is of type string");

        if (msg is string s)
            Console.WriteLine($"msg = {s}");


        DateTime dt = new DateTime();

        if (dt is not { Month: 10, Day: <=7, DayOfWeek: DayOfWeek.Friday })
            Console.WriteLine(dt.ToString());


    }
}