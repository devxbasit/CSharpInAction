using System;

class ValueTuple_Basic
{
    public static void Main()
    {

        // unnamed Tuple 
        ValueTuple<string, int, double> engine1 = ("Turbo 1", 100, 5.5);
        (string, int, double) engine2 = ("Turbo 2", 200, 6.6);
        var engine3 = ("Turbo 3", 300, 3.3);

        Console.WriteLine($"engine1.Item1 = {engine1.Item1}");

        // named Tuple -  (synonyms for the fields, Item1, Item2)
        /*
            These synonyms are only available at compile time because IDEs leverage the Roslyn APIs
            to make them available for you from the source code, but in the compiler intermediate
            language code, they are not available, only the unnamed fields—Item1, Item2, and
            so on.
        */
        var engine4 = (Name: "Turbo 4", Capacity: 400, Power: 4.4);
        Console.WriteLine($"engine4.Name = {engine4.Name}");
        Console.WriteLine($"engine4.Name = {engine4.Item1}");

        // The names for the fields can also be inferred from variables used to initialize the value tuple (as for C# 7.1)

        var name = "Turbo 5";
        var capacity = 5;

        var engine5 = (name, capacity, 5.5);
        Console.WriteLine($"engine5.name = {engine5.name}");
        Console.WriteLine($"engine5.Item3 = {engine5.Item3}");

        Console.WriteLine($"GetEngineUnnamedTuple() = {GetEngineUnnamedTuple()}");
        Console.WriteLine($"GetEngineNamedTuple() = {GetEngineNamedTuple()}");

        // Test for Equality and InEquality

        (int, long) t1 = (1, 2);
        (long, int) t2 = (1, 2);
        Console.WriteLine($"t1 == t2 : {t1 == t2}");

    }
    public static (string, int, double) GetEngineUnnamedTuple()
    {
        return ("Turbo", 10, 5.2);
    }
    public static (string Name, int Capacity, double Power) GetEngineNamedTuple()
    {
        return ("Turbo", 10, 5.2);
    }
}
