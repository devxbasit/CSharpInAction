using System;

class InterfaceReabstraction
{
    public static void Main()
    {
        IYellowLabrador l1 = new YellowLabrador("l1");
        Console.WriteLine($"Noise = {l1.Noise}");

    }
}

public interface IDog
{
    string Name { get; }

    // default implementation
    string Noise => "barks";
}


public interface ILabrador : IDog
{
    int RetrieverAbility { get; }

    //override default implementation
    string IDog.Noise => "woofs";
}


// Re-abstraction in action

// The ability to redefine the default implementation from a derived interface is fundamental 
// to understanding reabstraction. The principle is the same, but the deriving interface may 
// decide to erase the default interface implementation, marking the member as abstract.
public interface IYellowLabrador : ILabrador
{

    // re-abstract the default implementation

    // the implementers of the new interface are required to implement the Noise method
    abstract string IDog.Noise { get; }
}

public class YellowLabrador : IYellowLabrador
{
    public string Name { get; }
    public int RetrieverAbility { get; set; }
    public string Noise { get; set; }

    public YellowLabrador(string name)
    {
        this.Name = name;
        Noise = "beep";
    }
}

