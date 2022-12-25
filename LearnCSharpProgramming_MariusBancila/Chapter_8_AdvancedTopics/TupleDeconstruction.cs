using System;

class TupleDeconstruction
{
    public static void Main()
    {
        Engine engine = new Engine("Turbo 1", 50, 5.5);

        var (name, _, _) = engine.GetEngine();
        Console.WriteLine($"name = {name}");

        // tuple deconstruction 
        Engine engine2 = new Engine("Turbo 2", 2, 2.2);
        var (Name2, Capacity2, Power2) = engine;
        var (Name3, Power3) = engine;

        Console.WriteLine($"Name2 = {Name2}");
        Console.WriteLine($"Name3 = {Name3}");
    }
}

class Engine
{
    public String Name { get; private set; }
    public int Capacity { get; private set; }
    public double Power { get; private set; }

    public Engine(string name, int capacity, double power)
    {
        Name = name;
        Capacity = capacity;
        Power = power;
    }

    public void Deconstruct(out string name, out int capacity, out double power)
    {
        name = Name;
        capacity = Capacity;
        power = Power;
    }

    public void Deconstruct(out string name, out double power)
    {
        name = Name;
        power = Power;
    }

    public (string, int, double) GetEngine()
    {
        return (Name, Capacity, Power);
    }
}