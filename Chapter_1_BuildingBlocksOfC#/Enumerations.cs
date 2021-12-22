using System.Reflection.Emit;
using System;

class Enumerations{ 

    public static void Main() {

        Priority p = Priority.Normal;
        Console.WriteLine($"p = {p}");

        Priority p1 = (Priority)42;
        Priority p2 = 0;

        Console.WriteLine($"p1 = {p1}");
        Console.WriteLine($"p2 = {p2}");

        int i = (int)Priority.Normal;
        Console.WriteLine($"i = {i}");

        // case sensitive - "Normal != normal
        Enum.TryParse("Normal", out Priority p3);
        Console.WriteLine($"p3 = {p3}");


        // if you want to parse from a string ignoring the case, then you need to use a non-generic overload 
        Enum.TryParse(typeof(Priority), "NoRmAL", true, out object o);
        Priority p4 = (Priority)o;
        Console.WriteLine($"p4 = {p4}");

        Type T = typeof(Priority);
        Console.WriteLine($"T = {T}");

        string name = Enum.GetName(typeof(Priority), 10);
        Console.WriteLine($"Name = {name}");

        //see also -  Enum.GetNames,

    }

    enum Priority : byte{
        low = 10,
        Normal,
        Important = 20,
        Urgent,
    }
}