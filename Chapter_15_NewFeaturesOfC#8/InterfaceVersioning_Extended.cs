using System;

class InterfaceVersioning_Extended
{
    public static void Main()
    {

        // Traditionally, the interface versioning problem has been solved by creating a new interface 
        // that extends the previous one, but this solution isn't that practical, since the adoption of 
        // the new interface requires the implementers to replace the old interface with the new one 
        // in their object inheritance declaration and, of course, implement the new members.

        // The default implementation of ILabrador redefines the baseline implementation of 
        // Noise in IDog. This means that, even if we are using an IDog reference, the change in 
        // ILabrador will affect the result,

        IDog d1 = new Labrador("d1");
        Console.WriteLine(d1.Noise);

        ILabrador d2 = new Labrador("d2");
        Console.WriteLine(d2.Noise);

        Labrador d3 = new Labrador("d3");

        // Error
        // Console.WriteLine(d3.Noise);

    }
}


public interface IDog
{
    string Name { get; }

    string Noise => "barks";
}

public interface ILabrador : IDog
{
    int RetrieverAbility { get; }

    // later change - V2
    string Noise => "ILabrador Woofs"; // Version 2
    string IDog.Noise => "IDog Woofs"; // Version 2
}

public class Labrador : ILabrador
{
    public string Name { get; }

    // with setter
    public int RetrieverAbility { get; set; }


    public Labrador(string name)
    {
        this.Name = name;
    }
}