using System;
using System.Collections.Generic;

class Generic_TypeInference
{
    public static void Main()
    {

        Console.WriteLine(Sum<int>(1, 2));
        var t1 = new Tuple<int, string>(1, "hello");

        // Type Inference in action
        Console.WriteLine(Sum(1, 2));
        var t2 = Tuple.Create(1, (string)null);

    }

    public static T Sum<T>(T a, T b)
    {
        return a;
    }
}