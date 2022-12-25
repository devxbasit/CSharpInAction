using System;
using System.Collections.Generic;

class Generic_DefaultOperator
{
    public static void Main()
    {
        Console.WriteLine(default(string) == null);
        Console.WriteLine(default(int) == 0);
        Console.WriteLine(default(int?) == null);
    }

    public static T DefaultOrLast<T>(IEnumerable<T> source)
    {
        // null for reference types and nullable value types
        var ret = default(T);

        foreach (T item in source)
        {
            ret = item;
        }

        return ret;
    }
}