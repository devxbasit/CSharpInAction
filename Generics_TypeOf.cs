using System;
using System.Collections.Generic;

class Generic_TypeOf
{
    public static void Main()
    {
        DoSomething<int>();
    }

    public static void DoSomething<T>()
    {
        Console.WriteLine(typeof(T));
        Console.WriteLine(typeof(int));

        //The List`1 indicates that this is a generic type calledList with generic arity 1 (one type parameter), and the type arguments are shown in square brackets afterward
        Console.WriteLine(typeof(List<T>));
        Console.WriteLine(typeof(List<int>));
        Console.WriteLine(typeof(List<>));

        Console.WriteLine(typeof(List<int>).GetType());
        Console.WriteLine(new List<int>().GetType());
    }
}