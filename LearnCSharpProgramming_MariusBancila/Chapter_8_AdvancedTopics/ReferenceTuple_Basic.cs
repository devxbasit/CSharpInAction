using System;

class ReferenceTuple_Basic
{
    public static void Main()
    {
        /*
            The generic class, System. Tuple, can hold up to eight values of different types.
        */

        // Reference Tuples are Immutable
        var engine1 = new Tuple<string, int, double>("Turbo 1", 1500, 5.8);
        var engine2 = Tuple.Create("Turbo 2", 10, 9.8);

        Console.WriteLine($"Name = {engine2.Item1}, Capacity = {engine2.Item2}");

        // Nested Tuples
        var engine3 = Tuple.Create(1, 2, 3, 4, 5, 6, 7, Tuple.Create(8, 9, 10, 11));

        /*  inferred type for the variable engine is Tuple<string,
            int, int, double, int, string, int, Tuple<Tuple<int, int,
            int>>>.
        */
        Console.WriteLine($"engine3.Rest.Item1 = {engine3.Rest.Item1}");
        Console.WriteLine($"engine3.Rest.Item1.Item1 = {engine3.Rest.Item1.Item1}");
    }
}