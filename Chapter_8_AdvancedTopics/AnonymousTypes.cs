using System;
class AnonymousTypes
{
    public static void Main()
    {
        /*
            ***
                It is sometimes necessary to construct temporary objects that hold some values, usually
                a subset of some larger object
            ***
            Contains read-only Properties only, types of these properties are inferred by the compiler

            Anonymous types have the following properties:
                • They are implemented as sealed classes and are, therefore, reference types. 

        */

        // throws error - Cannot Assign null 
        //var o = new { Name = "Turbo", Capacity = null};

        var o = new { Name = "Turbo", Capacity = 100 };
        Console.WriteLine($"Name = {o.Name}, Capacity = {o.Capacity}");

        Engine engine = new Engine("Turbo", 10);

        var x = new { engine.Name, engine.Capacity };
        Console.WriteLine($"Name = {x.Name}, Capacity = {x.Capacity}");


        // They are directly derived from System.Object and can only be cast to System.Object

        // throws error 
        // Engine engine1 = (Engine)x;

    }
}

class Engine
{
    public String Name { get; set; }
    public int Capacity { get; set; }

    public Engine(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
    }
}